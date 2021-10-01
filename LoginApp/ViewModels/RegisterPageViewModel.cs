using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LoginApp.Helpers;
using LoginApp.Models;
using LoginApp.Services;
using LoginApp.Views.Pages;
using Xamarin.Forms;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LoginApp.ViewModels
{
    public class RegisterPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _errorMsg;
        private bool _activityIndicator;
        private string _email;
        private string _password;
        private string _confirmpassword;
        private IPageService _pageService;
        private ApiHelper _apiHelper;
        private UserModel userModel;
        private Uri _apiRoute;

        public ICommand BackToLoginButton { get; private set; }
        public ICommand RegisterButton { get; private set; }


        public RegisterPageViewModel(IPageService pageService, ApiHelper apiHelper) //ctor
        {
            _activityIndicator = false;
            _pageService = pageService;
            _apiHelper = apiHelper;
            _apiRoute = new Uri(@"https://localhost:9344/api/Account");

            BackToLoginButton = new Command(async () => await BackToLogin());
            RegisterButton = new Command(async () => await some(_apiRoute, new UserModel { UserName = _email, Email = _email, Password = _password, ConfirmPassword = _confirmpassword }));
            

        }

        // _apiRoute, new UserModel { UserName = _email, Email = _email, Password = _password, ConfirmPassword = _confirmpassword }

        public bool ErrorMsg { get { return _errorMsg; } set { _errorMsg = value; OnPropertyChanged(); } }

        public bool ActivityIndicator { get { return _activityIndicator; } set { _activityIndicator = value; OnPropertyChanged(); } }

        [Required]
        public string EmailField
        {
            get { return _email; }
            set { _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs(EmailField));
            }

        }
        [Required]
        public string PasswordField
        {
            get { return _password; }
            set { _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs(PasswordField));
            }
            
        }
        [Required]
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

        private async Task some(Uri route, UserModel model)
        {
            ActivityIndicator = true;
            ErrorMsg = false;
            var result = await _apiHelper.RegistrationPostRequest(route,model);

            if (result == "OK")
            {
                ErrorMsg = false;
                ActivityIndicator = false;
                await _pageService.PopAsync();
                await _pageService.DisplayAlert("Registration","Registration successful","Ok");
            }
            else
            {
                ActivityIndicator = false;
                ErrorMsg = true;
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }
}
