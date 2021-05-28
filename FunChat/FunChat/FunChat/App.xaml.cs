using System;
using FunChat.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunChat
{
    public partial class App : Application
    {
        private string PhoneNoKey = "PhoneNo";
        private string CountryCodeKey = "CountryCode";
        private string NameKey = "Name";
        private string DOBKey = "DOB";
        private string PINKey = "PIN";


        public string PhoneNo
        {
            get
            {
                if (!Current.Properties.TryGetValue(PhoneNoKey, out object phoneNo))
                {
                    phoneNo = null;
                }

                return phoneNo as string;
            }
            set
            {
                if (Current.Properties.ContainsKey(PhoneNoKey))
                {
                    Current.Properties[PhoneNoKey] = value;
                }
                else
                {
                    Current.Properties.Add(PhoneNoKey, value);
                }
            }
        }

        public string CountryCode
        {
            get
            {
                if (!Current.Properties.TryGetValue(CountryCodeKey, out object CountryCode))
                {
                    CountryCode = null;
                }

                return CountryCode as string;
            }
            set
            {
                if (Current.Properties.ContainsKey(CountryCodeKey))
                {
                    Current.Properties[CountryCodeKey] = value;
                }
                else
                {
                    Current.Properties.Add(CountryCodeKey, value);
                }
            }
        }

        public string Name
        {
            get
            {
                if (!Current.Properties.TryGetValue(NameKey, out object name))
                {
                    name = null;
                }

                return name as string;
            }
            set
            {
                if (Current.Properties.ContainsKey(NameKey))
                {
                    Current.Properties[NameKey] = value;
                }
                else
                {
                    Current.Properties.Add(NameKey, value);
                }
            }
        }

        public string DOB
        {
            get
            {
                if (!Current.Properties.TryGetValue(DOBKey, out object dob))
                {
                    dob = null;
                }

                return dob as string;
            }
            set
            {
                if (Current.Properties.ContainsKey(DOBKey))
                {
                    Current.Properties[DOBKey] = value;
                }
                else
                {
                    Current.Properties.Add(DOBKey, value);
                }
            }
        }

        public string PIN
        {
            get
            {
                if (!Current.Properties.TryGetValue(PINKey, out object pIN))
                {
                    pIN = null;
                }

                return pIN as string;
            }
            set
            {
                if (Current.Properties.ContainsKey(PINKey))
                {
                    Current.Properties[PINKey] = value;
                }
                else
                {
                    Current.Properties.Add(PINKey, value);
                }
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
