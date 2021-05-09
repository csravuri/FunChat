using FunChat.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FunChat.Models
{
    class LockCreationViewModel : BaseViewModel
    {
        public string PIN { get; set; }
        public ICommand PINEnteredCommand { get; private set; }
        public ICommand PINSkipedCommand { get; private set; }
        public LockCreationViewModel(INavigation navigation) : base(navigation)
        {
            PINEnteredCommand = new Command(async () => await ExecutePINEnteredCommand());
            PINSkipedCommand = new Command(async () => await ExecutePINSkipedCommand());
        }

        private async Task ExecutePINSkipedCommand()
        {
            await Navigation.PushAsync(new PersonalDetailsPage());
        }

        private async Task ExecutePINEnteredCommand()
        {
            if (IsPINValid())
            {
                await Navigation.PushAsync(new PersonalDetailsPage());
                //APP.PIN = PIN;
            }
        }

        private bool IsPINValid()
        {
            return true;
        }
    }
}
