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

        async void Progress_Clicked(object sender, EventArgs e)
        {
            ProgressPage.IsVisible = true;
            ProtectedPage.IsVisible = false;

        }
        async void Protected_Clicked(object sender, EventArgs e)
        {
            ProtectedPage.IsVisible = true;
            ProgressPage.IsVisible = false;

        }
    }
}
