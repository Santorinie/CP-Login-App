using System;
using System.Collections.Generic;
using LoginApp.Services;
using LoginApp.ViewModels;
using Xamarin.Forms;

namespace LoginApp.Views.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            var pageService = new PageService();

            BindingContext = new LoginPageViewModel(pageService);

            //var image = new Uri(@"https://bit.ly/3zB6MS6");

        }
    }
}
