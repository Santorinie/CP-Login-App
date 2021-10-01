using System;
using System.Collections.Generic;
using LoginApp.Helpers;
using LoginApp.Services;
using LoginApp.ViewModels;
using Xamarin.Forms;

namespace LoginApp.Views.Pages
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            var pageService = new PageService();
            var apihelper = new ApiHelper();
            BindingContext = new RegisterPageViewModel(pageService,apihelper);
        }
    }
}
