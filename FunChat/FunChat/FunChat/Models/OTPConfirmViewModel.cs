using FunChat.Services;
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
        private string _otp;
        public string OTP
        {
            get
            {
                return _otp;
            }
            set
            {
                SetProperty(ref _otp, value);
            }
        }

        private string _phoneNo;
        public string PhoneNo
        {
            get
            {
                return _phoneNo;
            }
            set
            {
                SetProperty(ref _phoneNo, value);
            }
        }

        private string _countryCode;
        public string CountryCode 
        { 
            get 
            { 
                return _countryCode; 
            } 
            set 
            { 
                SetProperty(ref _countryCode, value); 
            } 
        }
        public ICommand OTPEnteredCommand { get; private set; }
        public ICommand ChangePhoneNoCommand { get; private set; }
        private IFirebaseService _firebaseService;

        public OTPConfirmViewModel(INavigation navigation, IFirebaseService firebaseService) : base(navigation)
        {
            OTPEnteredCommand = new Command(async () => await ExecuteOTPEnteredCommand());
            ChangePhoneNoCommand = new Command(async () => await ExecuteChangePhoneNoCommand());
            _firebaseService = firebaseService;
            PhoneNo = APP.PhoneNo;
            CountryCode = APP.CountryCode;
        }

        private async Task ExecuteChangePhoneNoCommand()
        {
            // are you sure?
            await Navigation.PopAsync();
        }

        private async Task ExecuteOTPEnteredCommand()
        {
            if (IsOTPValid())
            {
                bool result = await _firebaseService.VerifyOTPCode(OTP);

                if (result)
                {
                    await Navigation.PushAsync(new LockCreationPage());
                }
            }
        }

        private bool IsOTPValid()
        {
            return true;
        }
    }
}
