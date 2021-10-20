using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using LoginApp.Helpers;
using LoginApp.Models;
using LoginApp.Services;
using LoginApp.Views.Pages;
using Xamarin.Forms;


namespace LoginApp.ViewModels
{
    
    public class LoginPageViewModel : INotifyPropertyChanged
    {

        // Local variables ---------------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private bool _errorMsg;
        private bool _activityIndicator;
        private bool _rememberMe;
        private string _errorText;
        private string _email;
        private string _password;
        private Uri _apiRoute;
        private ApiHelper _apiHelper;
        private IPageService _pageService;
        public ICommand LoginButton { get; private set; }
        public ICommand RegisterPageButton { get; private set; }
        public ICommand ForgotPasswordButton { get; private set; }
        private Uri _image;
        private bool _onGoingEvent;

        // Constructor -----------------------------------------------------------------------------------------------------------------

        public LoginPageViewModel(IPageService pageService, ApiHelper apiHelper) //ctor
        {
            _apiHelper = apiHelper;
            _pageService = pageService;
            UriBuilder uriBuilder = new UriBuilder(apiHelper.defRoute);
            uriBuilder.Path += "api/Account/Login";
            _apiRoute = uriBuilder.Uri;
            
            Image = new Uri("https://bit.ly/3kV5EUO");

            RegisterPageButton = new Command(async () => await PushRegisterPage());

            ForgotPasswordButton = new Command(async () => await PushModalForgotPasswordPage());

            

            LoginButton = new Command(async () => await LoginFunction(_apiRoute, new LoginModel { Email = EmailField, Password = PasswordField, RememberMe = RememberMe }));
        }



        // Properties ---------------------------------------------------------------------------------------------------------------

        public bool ErrorMsg { get { return _errorMsg; } set { _errorMsg = value; OnPropertyChanged(); } }

        public bool ActivityIndicator { get { return _activityIndicator; } set { _activityIndicator = value; OnPropertyChanged(); } }

        public bool RememberMe { get { return _rememberMe; } set { _rememberMe = value; OnPropertyChanged(); } }

        public string ErrorText { get { return _errorText; } set { _errorText = value; OnPropertyChanged(); } }

    


        public Uri Image
        {
            get { return _image; }
            set
            {
                _image = value;

            }
        }

        public string EmailField {
            get { return _email; }
            set { _email = value;
                OnPropertyChanged();
            }
        }
        
        public string PasswordField
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        // Functions ---------------------------------------------------------------------------------------------------------------

        private async Task LoginFunction(Uri route, LoginModel model)
        {
            if (_onGoingEvent == false)
            {
                _onGoingEvent = true;

                try
                {
                    ActivityIndicator = true;
                    ErrorMsg = false;
                    string result = await _apiHelper.PostRequest(route, model);

                    if (result == "OK")
                    {
                        ErrorMsg = false;
                        ActivityIndicator = false;
                        //await _pageService.PopAsync();
                        await _pageService.DisplayAlert("Login", "Login Successful", "Ok");
                        //redirect
                        await _pageService.PushAsync(new BarnePage());
                        //Empty props
                        EmailField = string.Empty;
                        PasswordField = string.Empty;
                    }
                    else
                    {
                        ActivityIndicator = false;
                        ErrorMsg = true;
                        ErrorText = "Login unsuccessful";
                    }
                    
                }
                catch (Exception)
                {
                    ActivityIndicator = false;
                    ErrorMsg = true;
                    ErrorText = "Connection with the server cannot be established";
                }
                _onGoingEvent = false;
            }
            else
            {
                
            }
        }

        private async Task PushRegisterPage()
        {
            await _pageService.PushAsync(new RegisterPage());
        }

        private async Task PushModalForgotPasswordPage()
        {
            await _pageService.PushModalAsync(new ForgotPasswordPage());
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
