using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ride2Earn.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina1 : ContentPage
    {
        public Pagina1()
        {
            InitializeComponent();
            lblVoornaam.FontSize = 20;
            lblAchternaam.FontSize = 20;
            lblEmail.FontSize = 20;
            lblGemeente.FontSize = 20;
            lblGereden.FontSize = 20;
            lblNummer.FontSize = 20;
            lblPostcode.FontSize = 20;
            lblRKnNummer.FontSize = 20;
            lblStraat.FontSize = 20;
            lblWachtwoord.FontSize = 20;
        }

        
    }
}