using Ride2Earn.Data;
using Ride2Earn.Helpers;
using Ride2Earn.Models;
using Ride2Earn.Views.Menu;
using Ride2Earn.Views.Pages;
using Ride2Earn.Views.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Ride2Earn
{
    public partial class App : Application
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

        public App(IRitRepository a)
        {
            InitializeComponent();

            if (IsFirstTime == "yes")
            {
                
                MainPage = new LoginPage1();
                IsFirstTime = "no";
            }
            else
            {
                MainPage = new MasterDetail()
                {
                    BindingContext = new RitViewModel(a),
                    
                };
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
