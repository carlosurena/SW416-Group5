using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace FitnessApp
{
    public class CardioViewModel : BaseViewModel
    {
        public CardioViewModel()
        {
            Title = "Cardio Workouts";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}
