using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ride2Earn.Views.Pages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ride2Earn.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> items;
        public MasterPage()
        {
            InitializeComponent();
            SetItems();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("Home", "Logo2.png", Color.White, typeof(Home)));
            items.Add(new MasterMenuItem("Mijn gegevens", "Logo2.png", Color.White, typeof(Pagina1)));
            ListView.ItemsSource = items;
        }
    }
}