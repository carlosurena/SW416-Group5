using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Prism.Navigation;
using Prism.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Reactive.Concurrency;

namespace FitnessApp
{
    public partial class MapPage : ContentPage
    { 
        Stopwatch stopWatch = new Stopwatch();

        public MapPage()
        {
            InitializeComponent();

            //Map location

            MyMap.MoveToRegion(
            MapSpan.FromCenterAndRadius(
                    new Position(37.785813, -122.406654), Distance.FromMiles(0.5)));


            //Add pins on map
            var position = new Position(37.781751, -122.410005); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Rest Area - Dottie's True Blue Cafe",
                Address = "28 6th St, San Francisco, CA 94103",
            };
            MyMap.Pins.Add(pin);

            //Polyline
            /*
            MyMap.Add(new Position(37.782249, -122.410636));
            MyMap.Add(new Position(37.781683, -122.415513));
            MyMap.Add(new Position(37.783555, -122.415908));
            MyMap.Add(new Position(37.784151, -122.410966));
            MyMap.
            */
        }
        public void BtnStartClicked(object sender, EventArgs e)
        {
            if (BtnStart.Text == "Start")
            {
                stopWatch.Start();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                    ts.Hours, ts.Minutes, ts.Seconds);
                lblStopWatch.Text = elapsedTime;
                BtnStart.Text = "Pause";

            }
            else
                BtnStart.Text = "Start";

        }
        public void BtnStopClicked(object sender, EventArgs e)
        {
            stopWatch.Stop();
            lblStopWatch.Text ="00:00:00";


            DisplayAlert("Alert", "Are you sure you're going to Stop? ", "Yes", "No");
        }
    }
}