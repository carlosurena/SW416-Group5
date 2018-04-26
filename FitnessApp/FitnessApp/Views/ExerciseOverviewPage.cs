using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace FitnessApp
{
    public partial class ExerciseOverviewPage : ContentPage
    {
        WorkoutViewModel viewModel;
        ObservableCollection<Exercise> ExerciseList = new ObservableCollection<Exercise>();

        public ExerciseOverviewPage()
        {
            InitializeComponent();

            var Exercise = new Exercise
            {
                name = "Exercise name",
                ItemID = 1,
                primaryBodyPart = "Primary Body Part",
                secondaryBodyPart = "Secondary Body Part"
            };


            //viewModel = new ExerciseDetailViewModel(Exercise);
            //BindingContext = viewModel;
        }

        public ExerciseOverviewPage(WorkoutViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            ExerciseList = viewModel.Exercises;
            Debug.WriteLine("Size of eList is: " + ExerciseList.Count);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Exercises.Count == 0)
                viewModel.LoadExercisesCommand.Execute(null);
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExercisePage());
        }
    }
}
