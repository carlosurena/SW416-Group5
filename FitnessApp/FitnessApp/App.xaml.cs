using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace FitnessApp
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";
        static WorkoutDatabase database;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }

        public static WorkoutDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new WorkoutDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("WorkoutSQLite.db3"));
                }
                Debug.WriteLine("DB Accessed");
                return database;
            }
        }
    }
}
