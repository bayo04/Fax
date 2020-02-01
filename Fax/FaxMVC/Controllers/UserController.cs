using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UserServices;
using Application.UserServices.Dtos;
using Core;
using FaxMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FaxMVC.Controllers
{
    public class UserController : Controller
    {
        public IUserAppService _userAppService { get; set; }
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AddUser(RegisterDto user)
        {
            _userAppService.Register(user);
            return View();
        }
    }
}