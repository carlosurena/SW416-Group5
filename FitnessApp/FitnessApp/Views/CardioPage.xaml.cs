﻿using System;
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
            BindingContext =  new CardioViewModel();
            BtnRun.BackgroundColor = Color.LightGreen;
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
            BtnRun.BackgroundColor = Color.LightGreen;
            BtnWalk.BackgroundColor = Color.DeepSkyBlue;
            BtnBike.BackgroundColor = Color.DeepSkyBlue;
        }
        async void BtnWalkClicked(object sender, EventArgs e)
        {
            RunPage.IsVisible = false;
            WalkPage.IsVisible = true;
            BikePage.IsVisible = false;
            BtnRun.BackgroundColor = Color.DeepSkyBlue;
            BtnWalk.BackgroundColor = Color.LightGreen;
            BtnBike.BackgroundColor = Color.DeepSkyBlue;
        }
        async void BtnBikeClicked(object sender, EventArgs e)
        {
            RunPage.IsVisible = false;
            WalkPage.IsVisible = false;
            BikePage.IsVisible = true;
            BtnRun.BackgroundColor = Color.DeepSkyBlue;
            BtnWalk.BackgroundColor = Color.DeepSkyBlue;
            BtnBike.BackgroundColor = Color.LightGreen;
        }

    }
}
