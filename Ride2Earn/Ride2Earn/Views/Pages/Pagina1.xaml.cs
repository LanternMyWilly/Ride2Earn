using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ride2Earn.Data;
using Ride2Earn.Klassen;
using Ride2Earn.Views.Dialogs;
using Rg.Plugins.Popup.Services;

namespace Ride2Earn.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina1 : ContentPage
    {
        public Pagina1()
        {
            InitializeComponent();
            BindingContext = new Gebruiker();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            lstGebruiker.ItemsSource = await App.Database.GetGebruikerAsync();
        }
        private async Task<string> Aanpassen()
        {
            // create the TextInputView
            var inputView = new TextInputView(
                "Geef je wachtwoord op", "wachtwoord...", "OK", "Annuleer", "Oeps! Dit veld mag niet leeg zijn!");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<string>(inputView);

            // subscribe to the TextInputView's Button click event
            inputView.SaveButtonEventHandler +=
                (sender, obj) =>
                {
                    if (!string.IsNullOrEmpty(((TextInputView)sender).TextInputResult))
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = false;
                        popup.PageClosedTaskCompletionSource.SetResult(((TextInputView)sender).TextInputResult);
                    }
                    else
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = true;
                    }
                };

            // subscribe to the TextInputView's Button click event
            inputView.CancelButtonEventHandler +=
                (sender, obj) =>
                {
                    popup.PageClosedTaskCompletionSource.SetResult(null);
                };

            // Push the page to Navigation Stack
            await PopupNavigation.PushAsync(popup);

            // await for the user to enter the text input
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
            return result;
        }
        /*async void Aanpassen(object sender, EventArgs e)
        {
            lstGebruiker.SelectedItem = (lstGebruiker.ItemsSource as List<Gebruiker>)[0];
            await Navigation.PushAsync(new GegevensAanpassen() { BindingContext = lstGebruiker.SelectedItem as Gebruiker });
            await Navigation.PushAsync(new TextInputView("a","b","c","d"));
        }*/

        /*async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                //await Navigation.PushAsync(new GegevensAanpassen() { BindingContext = e.SelectedItem as Gebruiker });
            }
        }*/
    }
}