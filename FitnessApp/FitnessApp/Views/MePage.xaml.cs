using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class MePage : ContentPage
    {
        MeViewModel viewModel;
        public MePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MeViewModel();
        }

        void Progress_Clicked(object sender, EventArgs e)
        {
            ProgressPage.IsVisible = true;
            ProtectedPage.IsVisible = false;

        }
        async void Protected_Clicked(object sender, EventArgs e)
        {
            ProgressPage.IsVisible = false;
            await DisplayAlert ("Password", "Enter Password", "Submit", "Cancel");
            ProtectedPage.IsVisible = true;

        }
        async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}