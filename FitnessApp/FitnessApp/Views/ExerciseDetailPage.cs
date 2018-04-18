using System;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class ExerciseDetailPage : ContentPage
    {
        public Exercise Exercise { get; set; }

        public ExerciseDetailPage()
        {
            InitializeComponent();

            Exercise = new Exercise
            {
                name = "Exercise name",
                primaryBodyPart = "Primary Body Part",
                secondaryBodyPart = "Secondary Body Part"
            };

            BindingContext = this;
        }

        public ExerciseDetailPage(Exercise exercise)
        {
            InitializeComponent();

            Exercise = new Exercise
            {
                name = exercise.name,
                primaryBodyPart = exercise.primaryBodyPart,
                secondaryBodyPart = exercise.secondaryBodyPart
            };

            BindingContext = this;
        }


        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddExercise", Exercise);

            Data.ExerciseList.Add(Exercise);
            await Navigation.PopAsync();
        }
    }
}
