using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Models.AdminPanel;


namespace OneMits.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ICategory _categoryImplementation;
        public AdminPanelController(ICategory categoryImplementation)
        {
            _categoryImplementation = categoryImplementation;
        }
        public IActionResult Index()
        {
            int SumQuestions = 0;
            var Categories = _categoryImplementation.GetAll();
            foreach (var category in Categories)
            {
                SumQuestions += category.Questions.Count();
            }
            var model = new PanelIndexModel
            {
                NumberForums = _categoryImplementation.GetAll().Count(),
                NumberQuestions = SumQuestions,
                //NumberMember = _categoryImplementation.GetAll().Count(),
                //NumberUser = _categoryImplementation.GetAll().Count(),
                //NumberReplies = _categoryImplementation.GetAll().Count(),
                //NumberLike = _categoryImplementation.GetAll().Count(),
            };

            return View(model);
        }

    }
}