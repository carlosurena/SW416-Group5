using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class WorkoutPage : ContentPage
    {
        WorkoutViewModel viewModel;
        Page meWorkout, featuredWorkouts = null;
        public WorkoutPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new WorkoutViewModel();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
