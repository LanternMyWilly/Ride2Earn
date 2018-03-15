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
    public partial class GegevensAanpassen : ContentPage
    {
        public GegevensAanpassen()
        {
            InitializeComponent();

        }

        async void Update(object sender, EventArgs e)
        {
            var aanpasen = (Gebruiker)BindingContext;
            await App.Database.SaveGebruikerAsync(aanpasen);
            await Navigation.PopAsync();
        }
    }
}