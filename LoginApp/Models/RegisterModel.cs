using System;
namespace LoginApp.Models
{
    public class RegisterModel
    {
        public RegisterModel()
        {
            
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
