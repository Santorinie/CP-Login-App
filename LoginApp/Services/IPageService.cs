using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginApp.Services
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PushModalAsync(Page page);
        Task<Page> PopAsync();
        Task<Page> PopModalAsync();

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
    }
}
