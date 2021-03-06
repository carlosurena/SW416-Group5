﻿using System;

using Xamarin.Forms;

namespace FitnessApp
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page mePage, workoutsPage,cardioPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    mePage = new NavigationPage(new MePage())
                    {
                        Title = "Me"
                    };

                    workoutsPage = new NavigationPage(new WorkoutPage())
                    {
                        Title = "Workouts"
                    };

                    cardioPage = new NavigationPage(new CardioPage())
                    {
                        Title = "Cardio"
                    };
                    mePage.Icon = "tab_feed.png";
                    workoutsPage.Icon = "tab_about.png";
                    cardioPage.Icon = "tab_about.png";
                    break;
                default:
                    mePage = new MePage()
                    {
                        Title = "Me"
                    };

                    workoutsPage = new WorkoutPage()
                    {
                        Title = "Workouts"
                    };
                    cardioPage = new CardioPage()
                    {
                        Title = "Cardio"
                    };
                    break;
            }

            Children.Add(mePage);
            Children.Add(workoutsPage);
            Children.Add(cardioPage);


            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
