
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Models.ApplicationUser;

namespace OneMits.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _profileManager;
        private readonly IApplicationUser _profileImplementation;
        public ProfileController(IApplicationUser profileImplementation, UserManager<ApplicationUser> profileManager)
        {
            _profileImplementation = profileImplementation;
            _profileManager = profileManager;
        }

        public IActionResult Details(string id)
        {
            var user = _profileImplementation.GetById(id);
            var userRoles = _profileManager.GetRolesAsync(user).Result;

            var model = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                EnrollmentNumber = user.EnrollmentNumber,
                UserRating = user.Rating.ToString(),
                MemberSince = user.MemberSince,
                Email = user.Email,
                IsAdmin = userRoles.Contains("Admin")
            };
            return View(model);
        }
    }
}