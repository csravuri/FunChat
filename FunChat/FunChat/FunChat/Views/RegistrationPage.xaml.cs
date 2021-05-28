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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadRegistrationCommand.Execute(null);
        }
    }
}