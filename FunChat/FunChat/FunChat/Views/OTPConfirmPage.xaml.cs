﻿using FunChat.Models;
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
    public partial class OTPConfirmPage : ContentPage
    {
        OTPConfirmViewModel viewModel;
        public OTPConfirmPage(OTPConfirmViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        private void OTP_Entered(object sender, EventArgs e)
        {
            viewModel.OTPEnteredCommand.Execute(null);

        }
    }
}