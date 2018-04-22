using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ride2Earn.Data;
using Ride2Earn.Klassen;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ride2Earn.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GegevensAanpassen : ContentPage
    {
        private Ride2EarnDatabase dataAccess;
        public GegevensAanpassen()
        {
            dataAccess = new Ride2EarnDatabase();
            InitializeComponent();

        }

        async void Update(object sender, EventArgs e)
        {
            double value;
            var aanpasen = (Gebruiker)BindingContext;
            if ((double.TryParse(EntryNummer.Text, out value)) && (double.TryParse(EntryPcode.Text, out value)))
            {
                dataAccess.SaveGebruikerAsync(aanpasen);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Fout ingave", "Gelieve een cijfer in te vullen bij nummer en/of postcode","OK");
            }
            
        }
    }
}