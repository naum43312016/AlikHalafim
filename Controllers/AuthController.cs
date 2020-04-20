using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlikHalafim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlikHalafim.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            
        }

        public IActionResult SignUp()
        {
            return View(new UserToRegister());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(UserToRegister model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName=model.Name,
                    Email=model.Email,
                    PhoneNumber=model.Phone
                };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                return Content(result.Errors.FirstOrDefault().Description);
            }
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View(new SignInModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    if (user.LockoutEnd != null)
                    {
                        model.Error = true;
                        return View(model);
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                model.Error = true;
                return View(model);
            }
            model.Error = true;
            return View(model);
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}