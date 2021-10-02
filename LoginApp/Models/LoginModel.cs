using System;
namespace LoginApp.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
