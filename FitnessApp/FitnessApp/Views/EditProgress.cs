using System;

using Xamarin.Forms;

namespace FitnessApp.Views
{
    public class EditProgress : ContentPage
    {
        public EditProgress()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

