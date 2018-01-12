using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using SQLite;
using System.IO;

namespace Ride2Earn.Droid
{
    [Activity(Label = "Ride2Earn", Icon = "@drawable/Logo2", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
             
            base.OnCreate(bundle);

            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "LocalRide2Earn.db");
            var RittenRepository = new RitRepository(dbPath);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(RittenRepository));

            var mainPage = new MainPage();//this could be content page
            var rootPage = new NavigationPage(mainPage);
        }
    }
}

