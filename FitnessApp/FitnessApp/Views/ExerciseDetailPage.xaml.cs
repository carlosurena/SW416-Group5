using System;

using Xamarin.Forms;

namespace FitnessApp
{
    public partial class ExerciseDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ExerciseDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Workout Name",
                Description = "Description"
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ExerciseDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddExercisePage());
        }
    }
}
