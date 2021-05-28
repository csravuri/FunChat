using FunChat.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FunChat.Models
{
    public class LoadingViewModel : BaseViewModel
    {
        public ICommand LoadLoadingViewModelCommand { get; private set; }
        public LoadingViewModel(INavigation navigation) : base(navigation)
        {
            LoadLoadingViewModelCommand = new Command(async () => await ExecuteLoadLoadingViewModelCommand());
        }

        private async Task ExecuteLoadLoadingViewModelCommand()
        {
            // there should be logic to decide which page to call 
            // for now registration 

            await Navigation.PushAsync(new RegistrationPage());

        }
    }
}
