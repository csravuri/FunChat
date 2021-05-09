using FunChat.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FunChat.Models
{
    public class PersonalDetailsViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public ICommand SaveDetailsCommand { get; private set; }
        public PersonalDetailsViewModel(INavigation navigation) : base(navigation)
        {
            SaveDetailsCommand = new Command(async () => await ExecuteSaveDetailsCommand());
        }

        private async Task ExecuteSaveDetailsCommand()
        {
            if (ArePersonalDetailsValid())
            {
                await Navigation.PushAsync(new HomePage());
                APP.Name = Name;
            }
        }

        private bool ArePersonalDetailsValid()
        {
            return true;
        }
    }
}
