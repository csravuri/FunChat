using FunChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunChat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalDetailsPage : ContentPage
    {
        PersonalDetailsViewModel viewModel;
        public PersonalDetailsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PersonalDetailsViewModel(this.Navigation);
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            viewModel.SaveDetailsCommand.Execute(null);
        }
    }
}