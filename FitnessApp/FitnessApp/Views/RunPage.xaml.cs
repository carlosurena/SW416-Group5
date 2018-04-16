using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class RunPage : StackLayout
    {
        public RunPage()
        {
            InitializeComponent();
        }


        async void BtnGoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }
        //  async void OnGoButtonClicked(object sender, EventArgs args)
        //{
        //  DisplayAlert("Alert", "Ready to Go?", "Yes", "No");  Clicked="OnGoButtonClicked" 
        //}

    }
}
