using Ride2Earn.Views.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Ride2Earn.Data;
using Ride2Earn.Helpers;
using Ride2Earn.Views.Menu;
using Ride2Earn.Models;
using Ride2Earn.Views.Pages;

namespace Ride2Earn
{
    public partial class App : Application
    {
        static Ride2EarnDatabase database;
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

        public App()
        {
            InitializeComponent();

            if (IsFirstTime == "yes")
            {

                MainPage = new LoginPage1();
                IsFirstTime = "no";
            }
            else
            {
                MainPage = new MasterDetail();
            }

        }

        public static Ride2EarnDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new Ride2EarnDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Ride2EarnDatabase.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        
    }
}
