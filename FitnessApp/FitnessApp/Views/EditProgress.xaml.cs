using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FitnessApp
{
    public partial class EditProgress : ContentPage
    {
        public EditProgress()
        {
            InitializeComponent();
        }
        void Slider_ValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == run_slider)
            {
                runLabel.Text = String.Format("Miles to Run = {0:N1}", (int)args.NewValue);
            }
            else if (sender == bike_slider)
            {
                bikeLabel.Text = String.Format("Miles to Bike = {0:N1}", (int)args.NewValue);
            }
            else if (sender == walk_slider)
            {
                walkLabel.Text = String.Format("Miles to Run = {0:N1}", (int)args.NewValue);
            }
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
          // MessagingCenter.Send(this, "SaveGoal");
          //  await Navigation.PopToRootAsync();
        }
    }
}
