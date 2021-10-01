using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginApp.Models;
using LoginApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace webapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;



        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        { 
            this._userManager = userManager;
            this._signInManager = signInManager;


        }

        [HttpGet]
        public IActionResult Register()
        {
            return Ok("Szia");
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok("Registration Successful");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                       ModelState.AddModelError("", item.Description);

                    }
                    
                }
            }
            else
            {
                
            }

            
        }



    }
}