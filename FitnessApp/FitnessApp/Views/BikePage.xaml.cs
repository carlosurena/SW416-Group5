using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class BikePage : StackLayout
    {
        public BikePage()
        {
            InitializeComponent();
        }
        async void BtnBikeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }
    }
}
