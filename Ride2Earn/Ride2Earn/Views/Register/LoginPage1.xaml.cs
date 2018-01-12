using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ride2Earn.Views.Register;

namespace Ride2Earn.Views.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage1 : ContentPage
    {
        public LoginPage1()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            btnNext.BackgroundColor = Constants.BackgroundTextColor;
            btnNext.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Password.FontSize = 15.5;
            Entry_Email.FontSize = 15.5;
            Entry_Voornaam.FontSize = 15.5;
            Entry_Familienaam.FontSize = 15.5;

            //Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            //Entry_Password.Completed += (s, e) => NextProcedure(s, e);
        }

        void NextProcedure(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage2());
            
        }
    }
}