using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ride2Earn.Models;
using Ride2Earn.Views.Pages;
using Ride2Earn.Views.Menu;

namespace Ride2Earn.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        
        public Home()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            lblAfstand.BackgroundColor = Constants.BackgroundTextColor;
            lblAfstand.TextColor = Constants.MainTextColor;

            btnBevestigen.BackgroundColor = Constants.BackgroundTextColor;
            btnBevestigen.TextColor = Constants.MainTextColor;

            Entry_Start.FontSize = 15.5;
            Entry_Einde.FontSize = 15.5;
            Entry_Afstand.FontSize = 15.5;
        }

        void Invullen(object sender, EventArgs e)
        {
            Gebruiker a = new Gebruiker(Entry_Start.Text, Entry_Einde.Text, Convert.ToDouble(Entry_Afstand.Text));
        }
    }
}