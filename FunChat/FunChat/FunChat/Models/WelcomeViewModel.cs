using FunChat.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FunChat.Models
{
    public class WelcomeViewModel : BaseViewModel
    {
        public ICommand ContinueClickedCommand { get; private set; }
        public WelcomeViewModel(INavigation navigation) : base(navigation)
        {
            ContinueClickedCommand = new Command(async () => await ExecuteContinueClickedCommand());
        }

        private async Task ExecuteContinueClickedCommand()
        {
            if (IsPhoneReady())
            {
                await Navigation.PushAsync(new RegistrationPage());
            }
        }

        private bool IsPhoneReady()
        {
            return base.IsNetworkAvailable();
        }
    }
}
