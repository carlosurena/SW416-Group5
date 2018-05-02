using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class WorkoutPage : ContentPage
    {
        WorkoutViewModel viewModel;
        //Page meWorkout, featuredWorkouts = null;
        public WorkoutPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new WorkoutViewModel();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        async void Me_Clicked(object sender, EventArgs e)
        {
            ItemList.IsVisible = true;
            FeaturedPage.IsVisible = false;
            ButtonContainer.BackgroundColor = Color.White;


        }
        async void Featured_Clicked(object sender, EventArgs e)
        {
            FeaturedPage.IsVisible = true;
            ItemList.IsVisible = false;
            ButtonContainer.BackgroundColor = Color.FromHex("#202020");

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
