using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class WalkPage : StackLayout
    {
        public WalkPage()
        {
            InitializeComponent();
        }
        async void BtnWalkClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }
    }
}
