﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class ExerciseList : StackLayout
    {
        public ExerciseList()
        {
            InitializeComponent();

            ExerciseListView.ItemsSource = Data.ExerciseList;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var exercise = args.SelectedItem as Exercise;
            if (exercise == null)
                return;

            await Navigation.PushAsync(new ExerciseDetailPage(exercise));

            // Manually deselect item
            ExerciseListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }


    }
}
