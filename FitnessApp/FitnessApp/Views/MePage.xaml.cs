using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitnessApp
{
    public partial class MePage : ContentPage
    {
        MeViewModel viewModel;
        public MePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MeViewModel();
        }

        void Progress_Clicked(object sender, EventArgs e)
        {
            ProgressPage.IsVisible = true;
            ProtectedPage.IsVisible = false;

        }
        async void Protected_Clicked(object sender, EventArgs e)
        {

            var result = await OpenPasswordPage();
            ProgressPage.IsVisible = false;
            ProtectedPage.IsVisible = true;

        }

        private async Task<string> OpenPasswordPage()
        {
            // create the TextInputView
            var inputView = new PasswordPage(
                "Enter Password", "Password", "Submit", "Cancel", "Invalid Password");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<string>(inputView);

            // subscribe to the TextInputView's Button click event
            inputView.SaveButtonEventHandler +=
                (sender, obj) =>
                {
                    if (!string.IsNullOrEmpty(((PasswordPage)sender).TextInputResult))
                    {
                        ((PasswordPage)sender).IsValidationLabelVisible = false;
                        popup.PageClosedTaskCompletionSource.SetResult(((PasswordPage)sender).TextInputResult);
                    }
                    else
                    {
                        ((PasswordPage)sender).IsValidationLabelVisible = true;
                    }
                };

            // subscribe to the TextInputView's Button click event
            inputView.CancelButtonEventHandler +=
                (sender, obj) =>
                {
                    popup.PageClosedTaskCompletionSource.SetResult(null);
                };

            // Push the page to Navigation Stack
            await PopupNavigation.PushAsync(popup);

            // await for the user to enter the text input
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
            return result;
        }


        async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}