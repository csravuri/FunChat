using FunChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunChat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LockCreationPage : ContentPage
    {
        LockCreationViewModel viewModel;
        public LockCreationPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LockCreationViewModel(this.Navigation);
        }

        private void Skip_Clicked(object sender, EventArgs e)
        {
            viewModel.PINSkipedCommand.Execute(null);
        }

        private void PIN_Entered(object sender, EventArgs e)
        {
            viewModel.PINEnteredCommand.Execute(null);
        }
    }
}