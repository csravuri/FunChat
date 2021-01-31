using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunChat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void Settings_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Under Developement", "This feature is coming soon", "OK");
        }

        private async void Search_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Under Developement", "This feature is coming soon", "OK");
        }

        private async void UserIcon_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Under Developement", "This feature is coming soon", "OK");
        }
    }
}