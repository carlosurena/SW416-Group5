using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FitnessApp
{
    public class WorkoutViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<Exercise> Exercises { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command LoadExercisesCommand { get; set; }
        public Item ParentItem { get; set; }

        public WorkoutViewModel()
        {
            Title = "Workouts";
            Items = new ObservableCollection<Item>();
            Exercises = new ObservableCollection<Exercise>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                //_item.ID = await App.Database.GetItemsAsync().Count;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });

        }

        public WorkoutViewModel(Item pItem){
            Title = pItem.Text;
            ParentItem = pItem;
            Exercises = new ObservableCollection<Exercise>();
            LoadExercisesCommand = new Command(async () => await ExecuteLoadExercisesCommand());

            MessagingCenter.Subscribe<AddExercisePage, Exercise>(this, "AddExercise", async (obj, item) =>
            {
                Debug.WriteLine("MSGCENTER exercise");
                var _item = item as Exercise;
                _item.ItemID = pItem.ID;
                Exercises.Add(_item);
                await App.Database.SaveExerciseAsync(_item);
                //Data.ExerciseList.Add(_item);
            });
        }



        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                Items.Clear();
                var items = await App.Database.GetItemsAsync();
                foreach (var item in items)
                {
                    Debug.WriteLine("Adding: " + item.Text + " to Items Collection... ID = "+item.ID);
                    Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadExercisesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Exercises.Clear();
                var exercises = await App.Database.GetExercisesAsync();
                //var items = await App.Database.GetItemsAsync();

                    foreach (var exercise in exercises)
                    {
                        Debug.WriteLine("Adding: " + exercise.name + " to Exercises Collection... ID = " + exercise.eID + "ItemID= " + exercise.ItemID);
                    if (ParentItem.ID == exercise.ItemID)
                        {
                            Exercises.Add(exercise);
                        Debug.WriteLine("Exercises in this list size: " + Exercises.Count+". PItemID:"+ParentItem.ID+" eID:"+exercise.ItemID);
                        }
                    }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
