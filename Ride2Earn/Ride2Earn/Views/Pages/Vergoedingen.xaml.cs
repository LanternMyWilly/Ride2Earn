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
    public partial class Vergoedingen : ContentPage
    {
        private Ride2EarnDatabase dataAccess;
        private Business bus;
        public Vergoedingen()
        {
            InitializeComponent();
            bus = new Business();
            dataAccess = new Ride2EarnDatabase();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = dataAccess;
            Aantalkm.Text = Convert.ToString(bus.AantalKM());
            Vergoeding.Text = bus.TotaleVergoeding();
            lstRitten.ItemsSource = dataAccess.GetRitten();
        }

        void ShowEvent(object sender, SelectedItemChangedEventArgs e)
        {
            var i = (lstRitten.ItemsSource as List<Rit>).IndexOf(e.SelectedItem as Rit);
            int Test = i;
            bus = new Business(Test);
            DisplayAlert("Informatie rit", bus.StartRit() + Environment.NewLine + bus.EindeRit() + Environment.NewLine + bus.DatumRit() + Environment.NewLine + bus.GeredenRit() + Environment.NewLine + Environment.NewLine + bus.VergoedingPerRit(),"OK");
        }

        async void Betalen(object sender, EventArgs e)
        {
            var antwoord = await DisplayAlert("Betaald", "Ben je zeker dat alles is betaald?" + Environment.NewLine + Environment.NewLine + "LET OP: Alle opgeslagen ritten worden verwijderd!", "JA", "NEE");
            if (antwoord)
            {
                Vergoeding.Text = string.Empty;
                Aantalkm.Text = string.Empty;
                var A2 = await DisplayAlert("Zeker?", "Ben je zeker?", "OK", "Cancel");
                if (A2)
                {
                    dataAccess.droptable();
                    dataAccess.createtable();
                    Navigation.InsertPageBefore(new Vergoedingen(), this);
                    await Navigation.PopAsync();
                }             
            }
        }
    }
}