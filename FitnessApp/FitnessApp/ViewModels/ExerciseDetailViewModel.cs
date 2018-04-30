using System;
using System.Diagnostics;

namespace FitnessApp
{
    public class ExerciseDetailViewModel : BaseViewModel
    {
        public Exercise Exercise { get; set; }
        public Item Item { get; set; }
        public ExerciseDetailViewModel(Exercise exercise)
        {
            //Title = exercise?.name;
            Exercise = exercise;

            Debug.WriteLine("Changing Exercise ItemID to " + Item.ID);
           // Exercise.ItemID = Item.ID;

        }
        public ExerciseDetailViewModel(Item item = null)
        {
            Title = item?.ID.ToString();
            Item = item;
            //if(item !=null){
            //    Exercise.ItemID = (int)item?.ID;
            //}
        }
    }
}
