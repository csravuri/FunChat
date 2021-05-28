using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace FunChat.Models
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected INavigation Navigation;
        protected App APP;
        public BaseViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            APP = Application.Current as App;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool IsNetworkAvailable()
        {
            // check internet connection
            // dispaly tost message
            return true;
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
