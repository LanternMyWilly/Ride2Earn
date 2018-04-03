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
        private Gebruiker a;
        private string ww;
        public Pagina1()
        {
            a = new Gebruiker();
            InitializeComponent();
            BindingContext = a;
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            lstGebruiker.ItemsSource = await App.Database.GetGebruikerAsync();
            a.Wachtwoord = ww;
        }
        private async Task<string> Aanpassen()
        {
            var result = string.Empty;
            // create the TextInputView
            var inputView = new TextInputView(
                "Geef je wachtwoord op", "wachtwoord...", "OK", "Annuleer", "Onjuist wachtwoord!");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<string>(inputView);

            // subscribe to the TextInputView's Button click event
            inputView.SaveButtonEventHandler +=
                (sender, obj) =>
                {
                    if (!string.IsNullOrEmpty(((TextInputView)sender).TextInputResult))
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = true;
                        lstGebruiker.SelectedItem = (lstGebruiker.ItemsSource as List<Gebruiker>)[0];
                        Navigation.PushAsync(new GegevensAanpassen() { BindingContext = lstGebruiker.SelectedItem as Gebruiker });
                    }
                    else
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = false;
                        popup.PageClosedTaskCompletionSource.SetResult(((TextInputView)sender).TextInputResult);
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
            result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
            return result;
        }
        /*async void Aanpassen(object sender, EventArgs e)
        {
            lstGebruiker.SelectedItem = (lstGebruiker.ItemsSource as List<Gebruiker>)[0];
            await Navigation.PushAsync(new GegevensAanpassen() { BindingContext = lstGebruiker.SelectedItem as Gebruiker });
        }*/
    }
}