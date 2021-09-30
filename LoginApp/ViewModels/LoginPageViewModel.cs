using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LoginApp.Services;
using LoginApp.Views.Pages;
using Xamarin.Forms;


namespace LoginApp.ViewModels
{
    
    public class LoginPageViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;
        private string _email;
        private string _password;
        private IPageService _pageService;

        public LoginPageViewModel(IPageService pageService) //ctor
        {

            _pageService = pageService;

            RegisterPageButton = new Command(async () => await PushRegisterPage());

            ForgotPasswordButton = new Command(async () => await PushForgotPasswordPage());
        }
        
        public ICommand LoginButton { get; private set; }
        public ICommand RegisterPageButton { get; private set; }
        public ICommand ForgotPasswordButton { get; private set; }
        
        

        public string EmailField {
            get { return _email; }
            set { _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs(EmailField));
            }
        }
        
        public string PasswordField
        {
            get { return _password; }
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs(PasswordField));
            }
        }

        private async Task PushRegisterPage()
        {
            await _pageService.PushAsync(new RegisterPage());
        }

        private async Task PushForgotPasswordPage()
        {
            await _pageService.PushModalAsync(new ForgotPasswordPage());
        }



        //private string sumfin;
        //public string Sumfin
        //{
        //    get { return sumfin; }
        //    set
        //    {
        //        sumfin = value;
        //        PropertyChanged(this, new PropertyChangedEventArgs(Sumfin));

        //    }
        //}

    }
}
