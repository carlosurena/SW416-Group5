﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class CardioPage : ContentPage
    {
        public CardioPage()
        {
            InitializeComponent();
        }
       
        void OnGoButtonClicked(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "Start?", "OK");
        }

    }
}
