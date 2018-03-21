using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace FitnessApp
{
    public class MeViewModel : BaseViewModel
    {
        public MeViewModel()
        {
            Title = "My Profile";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}
