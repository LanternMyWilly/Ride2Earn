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
            lstRitten.ItemsSource = dataAccess.GetRitten();
        }

        void ShowEvent(object sender, SelectedItemChangedEventArgs e)
        {
            var i = (lstRitten.ItemsSource as List<Rit>).IndexOf(e.SelectedItem as Rit);
            for (int teller = 1; teller < 50; teller++)
            {
                i += 1;
                int Test = i;
                bus = new Business(Test);
            }
            
            DisplayAlert("Hallo", bus.StartRit(), "OK");
        }
    }
}