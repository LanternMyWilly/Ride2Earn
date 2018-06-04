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
        private Business bus;
        public Home()
        {
            InitializeComponent();

            bus = new Business();
            dataAccess = new Ride2EarnDatabase();
            BindingContext = new Rit();

            StartPicker.ItemsSource = bus.GetStartAdressen();
            EindePicker.ItemsSource = bus.GetEindAdressen();

            EntryGereden.Text = string.Empty;
            EntryDatum.Text = string.Empty;        
            EntryStart.Text = string.Empty;
            EntryEinde.Text = string.Empty;

            if ((EntryStart.IsVisible == false) && (EntryEinde.IsVisible == false))
            {
                EntryDatum.Completed += (s, e) => EntryGereden.Focus();
                EntryGereden.Completed += (s, e) => AddEvent(s, e);
            }
            else if (EntryStart.IsVisible == false)
            {
                EntryDatum.Completed += (s, e) => EntryEinde.Focus();
                EntryEinde.Completed += (s, e) => EntryGereden.Focus();
                EntryGereden.Completed += (s, e) => AddEvent(s, e);
            }
            else if (EntryEinde.IsVisible == false)
            {
                EntryDatum.Completed += (s, e) => EntryStart.Focus();
                EntryStart.Completed += (s, e) => EntryGereden.Focus();
                EntryGereden.Completed += (s, e) => AddEvent(s, e);
            }
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

        void NieuwStart(object sender, EventArgs e)
        {
            Situatie3.IsVisible = true;
            Situatie1.IsVisible = false;
        }

        void NieuwStart1(object sender, EventArgs e)
        {
            Situatie2.IsVisible = false;
            Situatie3.IsVisible = true;
        }

        void NieuwEind(object sender, EventArgs e)
        {
            Situatie4.IsVisible = false;
            Situatie6.IsVisible = true;
        }
        

        void NieuwEind1(object sender, EventArgs e)
        {
            Situatie5.IsVisible = false;
            Situatie6.IsVisible = true;
        }

        void NieuwBestaand1(object sender, EventArgs e)
        {
            Situatie3.IsVisible = false;
            Situatie2.IsVisible = true;

        }

        void NieuwBestaand(object sender, EventArgs e)
        {
            Situatie1.IsVisible = false;
            Situatie2.IsVisible = true;
        }

        void EindBestaand(object sender, EventArgs e)
        {
            Situatie4.IsVisible = false;
            Situatie5.IsVisible = true;
        }

        void EindBestaand1(object sender, EventArgs e)
        {
            Situatie6.IsVisible = false;
            Situatie5.IsVisible = true;
        }

        void SelectStart(object sender, EventArgs e)
        {
            if (StartPicker.SelectedItem != null)
            {
                EntryStart.Text = Convert.ToString(StartPicker.SelectedItem);
                StartPicker.IsVisible = false;
                btnStartNieuw1.IsVisible = false;
                Situatie3.IsVisible = true;
            }
        }

        void SelectEinde(object sender, EventArgs e)
        {
            EntryEinde.Text = Convert.ToString(EindePicker.SelectedItem);
            EindePicker.IsVisible = false;
            btnEindNieuw1.IsVisible = false;
            Situatie6.IsVisible = true;
        }
    }
}