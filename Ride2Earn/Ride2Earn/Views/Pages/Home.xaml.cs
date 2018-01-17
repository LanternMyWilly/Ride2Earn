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
            EntryDatum.Text = string.Empty;
            
        }

        async void AddEvent(object sender, EventArgs e)
        {
            var rit = (Rit)BindingContext;
            await App.Database.SaveRitAsync(rit);
            await Navigation.PopAsync();
            EntryDatum.Text = string.Empty;
            EntryEinde.Text = string.Empty;
            EntryGereden.Text = string.Empty;
            EntryStart.Text = string.Empty;
        }
    }
}