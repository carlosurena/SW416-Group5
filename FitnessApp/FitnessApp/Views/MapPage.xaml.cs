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
using Xamarin.Forms.GoogleMaps;
using System.Reactive.Concurrency;
using System.Linq;

namespace FitnessApp
{
    public partial class MapPage : ContentPage
    {
        Stopwatch stopWatch = new Stopwatch();
        Polyline polyline = null;
        public MapPage()
        {
            InitializeComponent();
            

            //Map location

            map.MoveToRegion(
            MapSpan.FromCenterAndRadius(
                    new Position(41.158744, -73.256815), Distance.FromMiles(0.3)));

            //Add pins on map
            var position1 = new Position(41.1589638, -73.2577154); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "Rest Area - Tully",
                Address = "1073N Benson Rd, Fairfield, CT 06824",
            };
            map.Pins.Add(pin);

            //polyline
            polyline = new Polyline();
            polyline.StrokeColor = Color.Blue;
            polyline.StrokeWidth = 5f;
            polyline.Positions.Add(new Position(41.1611863, -73.2541933));
            polyline.Positions.Add(new Position(41.1602231, -73.2577875));
            polyline.Positions.Add(new Position(41.1603579, -73.2580356));
            polyline.Positions.Add(new Position(41.1602597, -73.2583645));
            polyline.Positions.Add(new Position(41.1604977, -73.2586189));
            polyline.Positions.Add(new Position(41.1610376, -73.2588064));
            polyline.Positions.Add(new Position(41.1612643, -73.2594099));
            polyline.Positions.Add(new Position(41.1616576, -73.2598085));
            polyline.Positions.Add(new Position(41.1613491, -73.2613005));
            polyline.Positions.Add(new Position(41.1609955, -73.2616153));
            polyline.Positions.Add(new Position(41.1598104, -73.2611669));
            polyline.Positions.Add(new Position(41.1596637, -73.2607925));
            polyline.Positions.Add(new Position(41.1581153, -73.2598390));
            polyline.Positions.Add(new Position(41.1580661, -73.2586883));
            polyline.Positions.Add(new Position(41.1587136, -73.2569479));
            map.Polylines.Add(polyline);
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
            lblStopWatch.Text = "00:00:00";


            DisplayAlert("Result page have not done yet", "Are you sure you're going to Stop? ", "Yes", "No");
        }

        //Responsive Layout
        private double width = 0;
        private double height = 0;
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    stackLayout.Orientation = StackOrientation.Horizontal;
                    stackBtn.Orientation = StackOrientation.Vertical;
                }
                else
                {
                    stackLayout.Orientation = StackOrientation.Vertical;
                }
            }
        }
        //End Responsive Layout
    }
}