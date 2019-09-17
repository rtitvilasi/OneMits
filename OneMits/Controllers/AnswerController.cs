using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Models.Answer;

namespace OneMits.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IQuestion _questionImplementation;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _applicationUserImplementation;
        public AnswerController(IQuestion questionImplementation, UserManager<ApplicationUser> userManager, IApplicationUser applicationUserImplementation)
        {
            _questionImplementation = questionImplementation;
            _userManager = userManager;
            _applicationUserImplementation = applicationUserImplementation;
        }

        public async Task<IActionResult> Create(int id)
        {
            var question = _questionImplementation.GetById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new AnswerModel
            {
                QuestionContent = question.QuestionContent,
                QuestionTitle = question.QuestionTitle,
                QuestionId = question.QuestionId,
                AuthorName = User.Identity.Name,
                AuthorId = user.Id,
                AuthorImageUrl = user.ProfileImageUrl,
                AuthorRating = user.Rating,
                IsAuthorAdmin = User.IsInRole("Admin"),

                CategoryTitle = question.Category.CategoryTitle,
                CategoryId = question.Category.CategoryId,
                CategoryImageUrl = question.Category.CategoryImageUrl,

                AnswerCreated = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswer(AnswerModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var answer = BuildReply(model, user);

            await _questionImplementation.AddAnswer(answer);
            await _applicationUserImplementation.UpdateUserRating(userId, typeof(Answer));

            return RedirectToAction("Index", "Question", new { questionid = model.QuestionId });
        }

        private Answer BuildReply(AnswerModel model, ApplicationUser user)
        {
            var question = _questionImplementation.GetById(model.QuestionId);
            return new Answer
            {
                Question = question,
                AnswerContent = model.AnswerContent,
                AnswerCreated = DateTime.Now,
                User = user
            };
        }

    }
}