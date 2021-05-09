using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FunChat.Models
{
    public class BaseViewModel
    {
        protected INavigation Navigation;
        protected App APP;
        public BaseViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            APP = Application.Current as App;
        }
    }
}
