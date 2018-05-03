using System;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class AddExercisePage : ContentPage
    {
        public Exercise Exercise { get; set; }

        public AddExercisePage()
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

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddExercise", Exercise);
            await Navigation.PopToRootAsync();
        }
    }
}
