using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LoginApp.Services;
using LoginApp.Views.Pages;
using Xamarin.Forms;

namespace LoginApp.ViewModels
{
    public class RegisterPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _email;
        private string _password;
        private string _confirmpassword;
        private IPageService _pageService;


        public RegisterPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            BackToLoginButton = new Command(async () => await BackToLogin());

        }

        public ICommand BackToLoginButton { get; private set; }
        public ICommand RegisterButton { get; private set; }



        public string EmailField
        {
            get { return _email; }
            set { _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs(EmailField));
            }

        }

        public string PasswordField
        {
            get { return _password; }
            set { _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs(PasswordField));
            }
            
        }

        public string ConfirmPasswordField
        {
            get { return _confirmpassword; }
            set
            {
                _confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs(ConfirmPasswordField));
            }

        }

        private async Task BackToLogin()
        {
            await _pageService.PopAsync();
            
        }
 


    }
}
