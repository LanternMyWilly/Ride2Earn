using Ride2Earn.Data;
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
    public partial class Home : ContentPage
    {
        
        public Home()
        {
            InitializeComponent();
        }

        void TonenEvent(object sender, EventArgs e)
        {
            UserDatabase a = new UserDatabase();
            Straat.Text = Convert.ToString(a.getUser());
        }
    }
}