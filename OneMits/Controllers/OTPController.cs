using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Views.OTP;

namespace OneMits.Controllers
{
    public class OTPController : Controller
    {
        private readonly UserManager<ApplicationUser> _profileManager;
        private readonly IApplicationUser _profileImplementation;

        public OTPController(UserManager<ApplicationUser> profileManager, IApplicationUser profileImplementation)
        {
            _profileManager = profileManager;
            _profileImplementation = profileImplementation;
        }

        public IActionResult Index()
        {
           
            return View();
        }
      
    }
}