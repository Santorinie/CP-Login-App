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
        private Uri _apiRoute;
        private string _errorText;
        private bool _onGoinEvent;

        public ICommand BackToLoginButton { get; private set; }
        public ICommand RegisterButton { get; private set; }

        private Uri _image;


        public Uri Image
        {
            get { return _image; }
            set
            {
                _image = value;

            }
        }


        public RegisterPageViewModel(IPageService pageService, ApiHelper apiHelper) //ctor
        {
            _activityIndicator = false;
            _pageService = pageService;
            _apiHelper = apiHelper;

            UriBuilder uriBuilder = new UriBuilder(apiHelper.defRoute);
            uriBuilder.Path += "api/Account/Register";
            _apiRoute = uriBuilder.Uri;

            BackToLoginButton = new Command(async () => await BackToLogin());
            RegisterButton = new Command(async () => await RegisterFunction(_apiRoute, new RegisterModel { UserName = _email, Email = _email, Password = _password, ConfirmPassword = _confirmpassword }));

            Image = new Uri("https://bit.ly/3F3GjA1");
        }


        public bool ErrorMsg { get { return _errorMsg; } set { _errorMsg = value; OnPropertyChanged(); } }

        public bool ActivityIndicator { get { return _activityIndicator; } set { _activityIndicator = value; OnPropertyChanged(); } }

        public string ErrorText { get { return _errorText; } set { _errorText = value; OnPropertyChanged(); } }


        public string EmailField
        {
            get { return _email; }
            set { _email = value;
                OnPropertyChanged();
            }

        }

        public string PasswordField
        {
            get { return _password; }
            set { _password = value;
                OnPropertyChanged();
            }
            
        }

        public string ConfirmPasswordField
        {
            get { return _confirmpassword; }
            set
            {
                _confirmpassword = value;
                OnPropertyChanged();
            }

        }

        private async Task BackToLogin()
        {
            await _pageService.PopAsync();
            
        }

        private async Task RegisterFunction(Uri route, RegisterModel model)
        {
            if (_onGoinEvent == false)
            {
                _onGoinEvent = true;

                try
                {
                    ActivityIndicator = true;
                    ErrorMsg = false;
                    string result = await _apiHelper.PostRequest(route, model);

                    if (result == "OK")
                    {
                        ErrorMsg = false;
                        ActivityIndicator = false;
                        await _pageService.PopAsync();
                        await _pageService.DisplayAlert("Registration", "Registration successful", "Ok");
                        //delete creds
                        EmailField = string.Empty;
                        PasswordField = string.Empty;
                        ConfirmPasswordField = string.Empty;
                    }
                    else
                    {
                        ActivityIndicator = false;
                        ErrorMsg = true;
                        ErrorText = "Registration unsuccessful";
                    }
                }
                catch (Exception)
                {
                    ActivityIndicator = false;
                    ErrorMsg = true;
                    ErrorText = "Connection with the server cannot be established";
                }
                _onGoinEvent = false;
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
