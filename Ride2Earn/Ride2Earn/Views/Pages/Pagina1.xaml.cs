using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ride2Earn.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina1 : ContentPage
    {
        public Pagina1()
        {
            InitializeComponent();
            
        }

        async void Do(object sender, EventArgs e)
        {
            Test.ItemsSource = await App.Database.GetGebruikerAsync();
            Test2.ItemsSource = await App.Database.GetRitAsync();
        }

        
    }
}