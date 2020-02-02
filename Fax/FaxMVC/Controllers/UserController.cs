using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UserServices;
using Application.UserServices.Dtos;
using Core;
using Core.Interfaces;
using FaxMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FaxMVC.Controllers
{
    public class UserController : Controller
    {
        public IUserService _userAppService { get; set; }
        public UserController(IUserService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> RegistrationHandler(CreateUserDto user)
        {
            var success = await _userAppService.Add(user);
            if (success)
            {
                return View("../Home/Index");
            }
            user.Password = "";
            RegisterViewModel model = new RegisterViewModel
            {
                User = user
            };
            return View("Register", model);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginHandler(LoginDto user)
        {
            
            return View();
        }
    }
}