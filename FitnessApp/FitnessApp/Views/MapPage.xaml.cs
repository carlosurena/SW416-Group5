using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FitnessApp
{
    public partial class MapPage : ContentPage
    {
        Map map;

        public MapPage()
        {
            InitializeComponent();


            var map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(41.158853, -73.257352), Distance.FromMiles(0.3)))//location of Fairfield University
            {
                IsShowingUser = true,
                HeightRequest = 250,
                VerticalOptions = LayoutOptions.Center
            };
            map.MapType = MapType.Street;
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
        }

        /*
        map = new Map
            {
                //IsShowingUser = true,
                HeightRequest = 250,
                // WidthRequest = 960,
                VerticalOptions = LayoutOptions.Center
            };

            map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));



            // create map style buttons

            map.MapType = MapType.Street;

            // put the page together
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);

            Content = stack;
        }*/
       
    } 
}