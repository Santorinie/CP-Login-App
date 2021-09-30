using System;
using LoginApp.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Nunito-Regular.ttf", Alias = "NunitoRegular" )]
[assembly: ExportFont("Nunito-Italic.ttf", Alias = "NunitoItalic" )]
[assembly: ExportFont("Nunito-ExtraBold.ttf", Alias = "NunitoExtraBold" )]
namespace LoginApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
