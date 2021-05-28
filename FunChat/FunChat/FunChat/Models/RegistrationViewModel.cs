using FunChat.Services;
using FunChat.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FunChat.Models
{
    public class RegistrationViewModel : BaseViewModel
    {
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
        private IFirebaseService _firebaseService;

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
        
        public ICommand PhoneNoEnteredCommand { get; private set; }
        public ICommand ContinueClickedCommand { get; private set; }
        public ICommand LoadRegistrationCommand { get; private set; }
        public RegistrationViewModel(INavigation navigation) : base(navigation)
        {
            PhoneNoEnteredCommand = new Command(async () => await ExecutePhoneNoEnteredCommand());
            ContinueClickedCommand = new Command(async () => await ExecuteContinueClickedCommand());
            LoadRegistrationCommand = new Command(async () => await ExecuteLoadRegistrationCommand());
        }

        private async Task ExecuteLoadRegistrationCommand()
        {
            if (string.IsNullOrWhiteSpace(CountryCode))
            {
                CountryCode = "1";
                PhoneNo = "1234567890";

                // get proper country code and 

                //RegionInfo b = new RegionInfo(CultureInfo.CurrentUICulture.LCID);

                //RegionInfo a = RegionInfo.CurrentRegion;

                //Placemark

                //ConfigurationCompat.getLocales(Resources.getSystem().getConfiguration());
            }
        }

        private async Task ExecutePhoneNoEnteredCommand()
        {
            //if (IsPhoneNoValid())
            //{
            //    await Navigation.PushAsync(new OTPConfirmPage());
            //    // save phone no in app properties
            //    APP.PhoneNo = PhoneNo;
            //}
        }

        private async Task ExecuteContinueClickedCommand()
        {
            if (IsPhoneNoValid())
            {
                _firebaseService = DependencyService.Get<IFirebaseService>();
                
                bool result = await _firebaseService.LoginWithPhone($"+{CountryCode}{PhoneNo}");

                if (result)
                {
                    await Navigation.PushAsync(new OTPConfirmPage(new OTPConfirmViewModel(this.Navigation, this._firebaseService)));
                    APP.PhoneNo = PhoneNo;
                    APP.CountryCode = CountryCode;
                }
            }
        }

        private bool IsPhoneNoValid()
        {
            if (!base.IsNetworkAvailable())
            {
                return false;
            }

            // phone no mandatory 
            // country code mandatory
            // as per country code no. of digits mandatory

            if (PhoneNo.Length != 10)
            {
                // throw error
            }

            return true;
        }
    }
}
