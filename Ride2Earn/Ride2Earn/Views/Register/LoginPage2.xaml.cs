﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ride2Earn.Models;
using Ride2Earn.Views.Register;
using Ride2Earn.Views.Menu;

namespace Ride2Earn.Views.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage2 : ContentPage
    {
        public LoginPage2()
        {
            InitializeComponent();
            Init();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Init()
        {
            btnRegister.BackgroundColor = Constants.BackgroundTextColor;
            btnRegister.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Gemeente.FontSize = 15.5;
            Entry_Nummer.FontSize = 15.5;
            Entry_Pcode.FontSize = 15.5;
            Entry_Straat.FontSize = 15.5;
        }

        void RegisterEvent(object sender, EventArgs e)
        {
            Gebruiker b = new Gebruiker(Convert.ToString(Entry_Straat.Text), Convert.ToString(Entry_Gemeente.Text), Convert.ToString(Entry_rknNummer.Text), Convert.ToInt16(Entry_Nummer.Text), Convert.ToInt16(Entry_Pcode.Text));
            Application.Current.MainPage = new NavigationPage(new MasterDetail());
            App.a.SaveUser(b);
        }
    }
}
