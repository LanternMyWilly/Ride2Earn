using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ride2Earn.Views.Register;
using Ride2Earn.Klassen;

namespace Ride2Earn.Views.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage1 : ContentPage
    {
        public LoginPage1()
        {
            InitializeComponent();
            BindingContext = new Gebruiker();
            NavigationPage.SetHasNavigationBar(this, false);
            Init();
        }

        void Init()
        {
            btnNext.BackgroundColor = Constants.BackgroundTextColor;
            btnNext.TextColor = Constants.MainTextColor;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Email.Text = string.Empty;
            Entry_Familienaam.Text = string.Empty;
            Entry_Password.Text = string.Empty;
            Entry_Voornaam.Text = string.Empty;

            Entry_Password.FontSize = 15.5;
            Entry_Email.FontSize = 15.5;
            Entry_Voornaam.FontSize = 15.5;
            Entry_Familienaam.FontSize = 15.5;

            Entry_Voornaam.Completed += (s, e) => Entry_Familienaam.Focus();
            Entry_Familienaam.Completed += (s, e) => Entry_Email.Focus();
            Entry_Email.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => NextProcedure(s, e);
        }

        void NextProcedure(object sender, EventArgs e)
        {
            if (Entry_Email.Text == string.Empty || Entry_Familienaam.Text == string.Empty || Entry_Password.Text == string.Empty || Entry_Voornaam.Text == string.Empty)
            {
                DisplayAlert("Mislukt", "Gelieve alle velden correct in te vullen.", "OK");
            }
            else
            {
                var a = (Gebruiker)BindingContext;
                Application.Current.MainPage = new NavigationPage(new LoginPage2(a));
            }
        }
    }
}