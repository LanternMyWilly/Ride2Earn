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
        public Vergoedingen()
        {
            InitializeComponent();
            dataAccess = new Ride2EarnDatabase();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = dataAccess;
            lstRitten.ItemsSource = dataAccess.GetRitten();
        }
    }
}