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
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        async void Me_Clicked(object sender, EventArgs e)
        {
            ItemList.IsVisible = true;
            FeaturedPage.IsVisible = false;

        }
        async void Featured_Clicked(object sender, EventArgs e)
        {
            FeaturedPage.IsVisible = true;
            ItemList.IsVisible = false;

        }
    }
}
