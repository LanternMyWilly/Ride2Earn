using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ride2Earn.Klassen;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ride2Earn.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vergoedingen : ContentPage
    {
        public Vergoedingen()
        {
            InitializeComponent();
            //BindingContext = new Rit();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            lstRitten.ItemsSource = await App.Database.GetRitAsync();
        }
    }
}