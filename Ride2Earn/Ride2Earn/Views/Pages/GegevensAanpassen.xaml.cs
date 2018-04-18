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
    public partial class GegevensAanpassen : ContentPage
    {
        private Ride2EarnDatabase dataAccess;
        public GegevensAanpassen()
        {
            dataAccess = new Ride2EarnDatabase();
            InitializeComponent();

        }

        async void Update(object sender, EventArgs e)
        {
            var aanpasen = (Gebruiker)BindingContext;
            dataAccess.SaveGebruikerAsync(aanpasen);
            await Navigation.PopAsync();
        }
    }
}