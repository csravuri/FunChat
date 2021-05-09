using FunChat.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FunChat.Models
{    
    public class OTPConfirmViewModel : BaseViewModel
    {
        public string OTP { get; set; }
        public ICommand OTPEnteredCommand { get; private set; }
        public OTPConfirmViewModel(INavigation navigation) : base(navigation)
        {
            OTPEnteredCommand = new Command(async () => await ExecuteOTPEnteredCommand());
        }

        private async Task ExecuteOTPEnteredCommand()
        {
            if (IsOTPValid())
            {
                await Navigation.PushAsync(new LockCreationPage());
            }
        }

        private bool IsOTPValid()
        {
            return true;
        }
    }
}
