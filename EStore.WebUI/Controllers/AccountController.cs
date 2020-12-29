using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStore.WebUI.IDentity;
using EStore.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        #region Injection Process
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User>userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Register Process
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var user = new User
            {
                UserName = model.UserName,
                Email=model.Email,
                fullname=model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("Account", "Login");
            }
            ModelState.AddModelError("", "Şifreniz en az 6 karakter-büyük küçük harf ve rakamlardan ve özel karakterlerden oluşmalıdır !");
            return View(model);
        }
        #endregion

        #region Login Process
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult>Login(LoginModel model,string returnurl)
        {
            returnurl = returnurl ?? "~/";
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user==null)
            {
                ModelState.AddModelError("", "Sistemde böyle bir kullanıcı bulunamadı");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if(result.Succeeded)
            {
                return Redirect(returnurl);
            }
            return View();
        }
        #endregion
    }
}