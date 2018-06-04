using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ride2Earn.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformatieDialog : ContentPage
    {
        public EventHandler CloseButtonEventHandler { get; set; }

        public InformatieDialog(string titletext,string infotext, string closeButtonText)
        {
            InitializeComponent();
            TitleLabel.Text = titletext;
            InfoLabel.Text = infotext;
            CloseButton.Text = closeButtonText;
            CloseButton.Clicked += CloseButton_Clicked;
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            CloseButtonEventHandler?.Invoke(this, e);
        }
    }
}