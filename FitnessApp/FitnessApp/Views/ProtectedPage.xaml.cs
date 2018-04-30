using System;
using System.Collections.Generic;
using FitnessApp.ViewModels;
using Xamarin.Forms;

namespace FitnessApp
{
    public partial class ProtectedPage : ContentPage
    {
        public ProtectedPage()
        {
            InitializeComponent();
            BindingContext = new ProtectedViewModel();
        }


    }
}
