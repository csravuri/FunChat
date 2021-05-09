using FunChat.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FunChat.Models
{
    public class RegistrationViewModel : BaseViewModel
    {
        public string PhoneNo { get; set; }
        
        public ICommand PhoneNoEnteredCommand { get; private set; }
        public RegistrationViewModel(INavigation navigation) : base(navigation)
        {
            PhoneNoEnteredCommand = new Command(async () => await ExecutePhoneNoEnteredCommand());
        }

        private async Task ExecutePhoneNoEnteredCommand()
        {
            if (IsPhoneNoValid())
            {
                await Navigation.PushAsync(new OTPConfirmPage());
                // save phone no in app properties
                APP.PhoneNo = PhoneNo;
            }
        }

        private bool IsPhoneNoValid()
        {
            return true;
        }
    }
}
