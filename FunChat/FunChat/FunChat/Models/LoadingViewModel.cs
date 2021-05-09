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
        public ICommand LoadLoadingViewModel { get; private set; }
        public LoadingViewModel(INavigation navigation) : base(navigation)
        {
            LoadLoadingViewModel = new Command(async () => await ExecuteLoadLoadingViewModel());
        }

        private async Task ExecuteLoadLoadingViewModel()
        {
            // there should be logic to decide which page to call 
            // for now registration 

            await Navigation.PushAsync(new RegistrationPage());

        }
    }
}
