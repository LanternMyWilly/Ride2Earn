using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ride2Earn.Models;
using Ride2Earn.Views.Register;
using Ride2Earn.Views.Menu;
using Ride2Earn.Klassen;

namespace Ride2Earn.Views.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage2 : ContentPage
    {
        public LoginPage2(Gebruiker b)
        {
            InitializeComponent();
            BindingContext = b;
            Init();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Init()
        {
            btnRegister.BackgroundColor = Constants.BackgroundTextColor;
            btnRegister.TextColor = Constants.MainTextColor;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Gemeente.FontSize = 15.5;
            Entry_Nummer.FontSize = 15.5;
            Entry_Postcode.FontSize = 15.5;
            Entry_Straat.FontSize = 15.5;
            Entry_rknNummer.FontSize = 15.5;
            Entry_Nummer.Text = string.Empty;

            Entry_Straat.Completed += (s, e) => Entry_Nummer.Focus();
            Entry_Nummer.Completed += (s, e) => Entry_Postcode.Focus();
            Entry_Postcode.Completed += (s, e) => Entry_Gemeente.Focus();
            Entry_Gemeente.Completed += (s, e) => Entry_rknNummer.Focus();
            Entry_rknNummer.Completed += (s, e) => RegisterEvent(s, e);
        }

        async void RegisterEvent(object sender, EventArgs e)
        {
            var gebruiker = (Gebruiker)BindingContext;
            await App.Database.SaveGebruikerAsync(gebruiker);
            await Navigation.PopAsync();
            Application.Current.MainPage = new NavigationPage(new MasterDetail());
        }
    }
}