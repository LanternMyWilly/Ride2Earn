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
            DateTime date;
            double value = 0;
            var rit = (Rit)BindingContext;
            if (EntryDatum.Text != string.Empty && EntryEinde.Text != string.Empty && EntryStart.Text != string.Empty && EntryGereden.Text != string.Empty)
            {   
                if ((DateTime.TryParse(EntryDatum.Text, out date)) && (double.TryParse(EntryGereden.Text, out value)))
                {
                    dataAccess.SaveRit(rit);
                    DisplayAlert("Succesvol", "Rit succesvol opgeslagen.", "OK");
                    Navigation.InsertPageBefore(new Home(), this);
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Fout ingave", "Gelieve elk veld correct in te vullen. (volgens het voorbeeld)", "OK");
                    EntryDatum.Text = string.Empty;
                    EntryStart.Text = string.Empty;
                    EntryEinde.Text = string.Empty;
                    EntryGereden.Text = string.Empty;
                }
                
            }
            else
            {
                DisplayAlert("Mislukt", "Gelieve alle velden correct in te vullen.", "OK");
            }           
        }
    }
}