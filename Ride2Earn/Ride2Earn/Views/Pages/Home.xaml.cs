using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ride2Earn.Klassen;

namespace Ride2Earn.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            BindingContext = new Rit();
            EntryGereden.Text = string.Empty;
        }

        async void AddEvent(object sender, EventArgs e)
        {
            var rit = (Rit)BindingContext;
            await App.Database.SaveRitAsync(rit);
            await Navigation.PopAsync();

        }
        async void RefreshEvent(object sender, EventArgs e)
        {
            listView.ItemsSource = await App.Database.GetRitAsync();
        }
    }
}