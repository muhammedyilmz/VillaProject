using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Villa.Dto.Dtos.IdentityDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                NameSurname = registerDto.NameSurname,
                Email = registerDto.Email,
                UserName = registerDto.UserName
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();

            }
            return RedirectToAction("Login");

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }
            return RedirectToAction("Index", "Banner");
        }


    }
}