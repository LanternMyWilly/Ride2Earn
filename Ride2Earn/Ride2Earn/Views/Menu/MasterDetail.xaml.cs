using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ride2Earn.Views.Pages;

namespace Ride2Earn.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public new List<MasterMenuItem> menulist { get; set; }

        public MasterDetail()
        {
            InitializeComponent();
            menulist = new List<MasterMenuItem>();
            NavigationPage.SetHasNavigationBar(this, false);
            var page1 = new MasterMenuItem() { Title = "Home", Icon = "Home.png", TargetType = typeof(Home) };
            var page2 = new MasterMenuItem() { Title = "Profiel", Icon = "Person.png", TargetType = typeof(Pagina1) };
            var page3 = new MasterMenuItem() { Title = "Vergoedingen", Icon = "Geld.png", TargetType = typeof(Vergoedingen) };
            menulist.Add(page1);
            menulist.Add(page2);
            menulist.Add(page3);
            navigationDrawerList.ItemsSource = menulist;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Home)));
            this.BindingContext = new
            {
                Header = "",
                Image = "Logo2.png",
                Footer = ""
            };
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterMenuItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}