using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class ProgressPage : ScrollView
    {
        public ProgressPage()
        {
            InitializeComponent();
        }
        async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProgress());
        }

    }
}
