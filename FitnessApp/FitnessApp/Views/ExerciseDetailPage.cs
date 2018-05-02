using System;
using System.Diagnostics;
using System.Linq;
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
                Text="",
                HorizontalTextAlignment = TextAlignment.Center
            },1, xval);
            WorkoutGrid.Children.Add(new Entry
            {
                Text = "",
                HorizontalTextAlignment = TextAlignment.Center
            }, 2, xval);
            WorkoutGrid.Children.Add(addButton, yval, xval+1);
            WorkoutGrid.Children.Add(deleteButton, yval-1, xval + 1);
            //this.ForceLayout();

            //await Navigation.PopAsync();
        }
        async void DeleteSet_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddExercise", Exercise);

            int row = (int)Grid.GetRow(addButton);
            int col = (int)Grid.GetColumn(addButton);
            Debug.WriteLine(row + " " + col);
            //WorkoutGrid.RowDefinitions.Insert((int)xval, new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //WorkoutGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            //WorkoutGrid.Children.RemoveAt(row-1);
            //WorkoutGrid.RowDefinitions.RemoveAt(row - 1);
            if (row > 2)
            {
                var children = WorkoutGrid.Children.ToList();
                foreach (var child in children.Where(child => Grid.GetRow(child) == row))
                {
                    WorkoutGrid.Children.Remove(child);
                }
                foreach (var child in children.Where(child => Grid.GetRow(child) > row))
                {
                    Grid.SetRow(child, Grid.GetRow(child) - 1);
                }
                WorkoutGrid.Children.Add(addButton, col, row - 1);
                WorkoutGrid.Children.Add(deleteButton, col - 1, row - 1);
                //await Navigation.PopAsync();
            }
        }


    }
}
