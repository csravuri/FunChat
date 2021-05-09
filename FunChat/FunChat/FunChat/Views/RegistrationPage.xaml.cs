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
    public partial class RegistrationPage : ContentPage
    {
        RegistrationViewModel viewModel;
        public RegistrationPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RegistrationViewModel(this.Navigation);
        }

        private void PhoneNo_Entered(object sender, EventArgs e)
        {
            viewModel.PhoneNoEnteredCommand.Execute(null);
        }
    }
}