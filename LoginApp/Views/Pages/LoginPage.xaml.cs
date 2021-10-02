using System;
using System.Collections.Generic;
using LoginApp.Helpers;
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

            ApiHelper apiHelper = new ApiHelper();

            BindingContext = new LoginPageViewModel(pageService,apiHelper);

            //var image = new Uri(@"https://bit.ly/3zB6MS6");

        }
    }
}
