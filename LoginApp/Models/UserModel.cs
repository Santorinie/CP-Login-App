using System;
namespace LoginApp.Models
{
    public class UserModel
    {
        public UserModel()
        {
            
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
