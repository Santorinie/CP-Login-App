using System;
using System.Collections.Generic;
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
            BindingContext = new RegisterPageViewModel(pageService);
        }
    }
}
