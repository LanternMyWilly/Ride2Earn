using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ride2Earn.Data;
using Ride2Earn.Helpers;
using Ride2Earn.Klassen;
using Ride2Earn.Views.Menu;
using Ride2Earn.Views.Register;
using Xamarin.Forms;

namespace Ride2Earn
{
    public class SplashPage : ContentPage
    {
        public string IsFirstTime
        {
            get { return Settings.GeneralSettings; }
            set
            {
                if (Settings.GeneralSettings == value)
                    return;
                Settings.GeneralSettings = value;
            }
        }

        Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "LogoNav.png",
                WidthRequest = 100,
                HeightRequest = 100
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#FFFFFF");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            Business bus = new Business();
            Ride2EarnDatabase db = new Ride2EarnDatabase();
            base.OnAppearing();

            await splashImage.ScaleTo(1, 200);
            await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await splashImage.ScaleTo(1500, 1, Easing.Linear);
            if (IsFirstTime == "yes")
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage1()); ;
                IsFirstTime = "no";
            }
            else
            {
                if (bus.CheckIfExists() != string.Empty)
                {
                    Application.Current.MainPage = new NavigationPage(new MasterDetail());
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(new LoginPage1()); ;
                    IsFirstTime = "no";
                }
            }
        }
    }
}
