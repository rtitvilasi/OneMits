using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;

namespace OneMits.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ICategory _categoryImplementation;
        public AdminPanelController( ICategory categoryImplementation)
        {
            _categoryImplementation = categoryImplementation;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _categoryImplementation.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}