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
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
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
                    
                    return BadRequest("Something went wrong");
                    
                }
            }
            else
            {
                return BadRequest("Missing Parameters");
            }

            
        }


        [HttpGet]
        [ActionName("Login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);
                if (result.Succeeded)
                {
                    return Ok("Login Successful");
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"Invalid login attempt");
                    return BadRequest("Login failed");
                }
            }
            else
            {
                return BadRequest("Invalid modelstate");
            }


        }

    }
}