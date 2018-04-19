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
        private Rit a;
        public Vergoedingen()
        {
            InitializeComponent();
            bus = new Business();
            a = new Rit();
            BindingContext = a;
            dataAccess = new Ride2EarnDatabase();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //BindingContext = dataAccess;
            Aantalkm.Text = Convert.ToString(bus.AantalKM());
            lstRitten.ItemsSource = dataAccess.GetRitten();
        }

        void ShowDialog(object sender, EventArgs e)
        {
            
            int test = a.ID;
            DisplayAlert("test",bus.GeredenRit(), "OK");
        }
    }
}