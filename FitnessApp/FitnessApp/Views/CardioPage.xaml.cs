using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class CardioPage : ContentPage
    {
        public CardioPage()
        {
            InitializeComponent();
        }
       
     /*   async void OnGoButtonClicked(object sender, EventArgs args)
        {
            //DisplayAlert("Alert", "Start?", "OK");
            await Navigation.PushAsync(new MapPage());
            //MapPage.IsVisible = true;

        }
        */
        async void BtnRunClicked(object sender, EventArgs e)
        {
            RunPage.IsVisible = true;
            WalkPage.IsVisible = false;
            BikePage.IsVisible = false;

        }
        async void BtnWalkClicked(object sender, EventArgs e)
        {
            RunPage.IsVisible = false;
            WalkPage.IsVisible = true;
            BikePage.IsVisible = false;

        }
        async void BtnBikeClicked(object sender, EventArgs e)
        {
            RunPage.IsVisible = false;
            WalkPage.IsVisible = false;
            BikePage.IsVisible = true;

        }

    }
}
