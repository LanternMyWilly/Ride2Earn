using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ride2Earn.Klassen;
using Ride2Earn.Data;

namespace Ride2Earn.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private Ride2EarnDatabase dataAccess;
        public Home()
        {
            InitializeComponent();
            EntryGereden.Text = string.Empty;
            EntryDatum.Text = string.Empty;
            BindingContext = new Rit();
            dataAccess = new Ride2EarnDatabase();
            EntryGereden.Text = string.Empty;
            EntryDatum.Text = string.Empty;
            
        }

        void AddEvent(object sender, EventArgs e)
        {
            var rit = (Rit)BindingContext;
            if (EntryDatum.Text != string.Empty && EntryEinde.Text != string.Empty && EntryStart.Text != string.Empty && EntryGereden.Text != string.Empty)
            {
                dataAccess.SaveRit(rit);
                Navigation.PopAsync();
                EntryDatum.Text = string.Empty;
                EntryEinde.Text = string.Empty;
                EntryGereden.Text = string.Empty;
                EntryStart.Text = string.Empty;
                DisplayAlert("Succesvol", "Rit succesvol opgeslagen.", "OK");
            }
            else
            {
                DisplayAlert("Mislukt", "Gelieve alle velden correct in te vullen.", "OK");
            }           
        }
    }
}