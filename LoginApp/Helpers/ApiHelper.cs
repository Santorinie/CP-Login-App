using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LoginApp.Models;
using LoginApp.ViewModels;
using LoginApp.Views.Pages;

namespace LoginApp.Helpers
{
    public class ApiHelper
    {
        public ApiHelper()
        {
        }

        public async Task GetMethod(Uri route)
        {
            HttpClientHandler insecureHandler = GetInsecureHandler();
            HttpClient httpClient = new HttpClient(insecureHandler);

            var response = await httpClient.GetAsync(route);
        }
        

        public async Task<string> RegistrationPostRequest(Uri route, UserModel model)
        {
            HttpClientHandler insecureHandler = GetInsecureHandler();
            HttpClient httpClient = new HttpClient(insecureHandler);
            
            var modelSerialized = JsonSerializer.Serialize(model);
            var stringcontent = new StringContent(modelSerialized, Encoding.UTF8,"application/json");
            var response = await httpClient.PostAsync(route,stringcontent);

            if (response.IsSuccessStatusCode)
            {
                var fasz = response.ReasonPhrase;
                return response.ReasonPhrase;
                
                
            }
            else
            {
                var fasz = response.ReasonPhrase;
                return response.ReasonPhrase;
            }
        }

        // This method makes iOS and Android ignore self-signed (localhost) SSL certificates.
        // This method must be in a class in a platform project, even if
        // the HttpClient object is constructed in a shared project.
        private HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}
