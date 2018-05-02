using System;
using System.Diagnostics;

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


        async void AddSet_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddExercise", Exercise);

            int xval = (int)Grid.GetRow(addButton);
            int yval = (int)Grid.GetColumn(addButton);
            Debug.WriteLine(xval + " " + yval);
            WorkoutGrid.RowDefinitions.Insert((int)xval, new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            WorkoutGrid.Children.Add(new Label
            {
                Text = xval.ToString(),
                HorizontalTextAlignment = TextAlignment.Center
            }, 0, xval);
            WorkoutGrid.Children.Add(new Entry{
                Text=""
            },1, xval);
            WorkoutGrid.Children.Add(new Entry
            {
                Text = ""
            }, 2, xval);
            WorkoutGrid.Children.Add(addButton, yval, xval+1);

            //this.ForceLayout();

            //await Navigation.PopAsync();
        }


    }
}
