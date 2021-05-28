using FunChat.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FunChat.Models
{
    public class PersonalDetailsViewModel : BaseViewModel
    {

        public string Name { get; set; }
        private string _image;

        public string Image 
        { 
            get 
            {
                return _image;
            } 
            set 
            {
                SetProperty(ref _image, value);
            } 
        }

        private string _dob;

        public string DOB
        {
            get
            {
                return _dob;
            }
            set
            {
                SetProperty(ref _dob, value);
            }
        }

        public ICommand SaveDetailsCommand { get; private set; }
        public ICommand SelectImageCommand { get; private set; }
        public PersonalDetailsViewModel(INavigation navigation) : base(navigation)
        {
            SaveDetailsCommand = new Command(async () => await ExecuteSaveDetailsCommand());
            SelectImageCommand = new Command(async () => await ExecuteSelectImageCommand());
        }

        private async Task ExecuteSelectImageCommand()
        {
            PickOptions options = new PickOptions()
            {
                PickerTitle = "Select Image",
                FileTypes = FilePickerFileType.Images
            };

            FileResult picker = await FilePicker.PickAsync(options);

            if (picker != null)
            {
                string destinationPath = Path.Combine(Environment.SpecialFolder.MyDocuments.ToString(), "Profile", picker.FileName);
                File.Copy(picker.FullPath, destinationPath, true);

                Image = destinationPath;
            }
        }

        private async Task ExecuteSaveDetailsCommand()
        {
            if (ArePersonalDetailsValid())
            {
                await Navigation.PushAsync(new HomePage());
                APP.Name = Name;
                APP.DOB = DOB;                
            }
        }

        private bool ArePersonalDetailsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }

            return true;
        }
    }
}
