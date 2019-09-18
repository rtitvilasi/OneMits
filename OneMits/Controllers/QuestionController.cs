﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Models.Answer;
using OneMits.Models.Question;

namespace OneMits.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestion _questionImplementation;
        private readonly ICategory _categoryImplementation;
        private readonly IApplicationUser _applicationUserImplementation;

        private static UserManager<ApplicationUser> _userManager;

        public QuestionController(IQuestion questionImplementation, ICategory categoryImplementation, IApplicationUser applicationUserImplementation, UserManager<ApplicationUser> userManager)
        {
            _questionImplementation = questionImplementation;
            _categoryImplementation = categoryImplementation;
            _applicationUserImplementation = applicationUserImplementation;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var question = _questionImplementation.GetById(id);
            var answers = Buildanswers(question.Answers);
            var model = new QuestionIndexModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                AuthorId = question.User.Id,
                AuthorName = question.User.UserName,
                AuthorImageUrl = question.User.ProfileImageUrl,
                AuthorRating = question.User.Rating,
                QuestionCreated = question.QuestionCreated,
                QuestionContent = question.QuestionContent,
                Answers = answers,
                CategoryId = question.Category.CategoryId,
                CategoryTitle = question.Category.CategoryTitle,
                IsAuthorAdmin = IsAuthorAdmin(question.User)

            };

            return View(model);
        }

        private IEnumerable<AnswerModel> Buildanswers(IEnumerable<Answer> answers)
        {
            return answers.Select(answer => new AnswerModel
            {
                AnswerId = answer.AnswerId,
                AuthorName = answer.User.UserName,
                AuthorId = answer.User.Id,
                AuthorImageUrl = answer.User.ProfileImageUrl,
                AuthorRating = answer.User.Rating,
                AnswerCreated = answer.AnswerCreated,
                AnswerContent = answer.AnswerContent,
                IsAuthorAdmin = IsAuthorAdmin(answer.User)

            });

        }
        private bool IsAuthorAdmin(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user).Result.Contains("Admin");
        }

        public IActionResult Create(int id)
        {
            var category = _categoryImplementation.GetById(id);
            var model = new NewQuestionModel
            {
                CategoryTitle = category.CategoryTitle,
                CategoryId = category.CategoryId,
                CategoryImageUrl = category.CategoryImageUrl,
                AuthorName = User.Identity.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(NewQuestionModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var question = BuildPost(model, user);

            await _questionImplementation.Add(question);
            await _applicationUserImplementation.UpdateUserRating(userId, typeof(Question));

            return RedirectToAction("Index", "Question", new { questionid = question.QuestionId });

        }

        private Question BuildPost(NewQuestionModel model, ApplicationUser user)
        {
            var category = _categoryImplementation.GetById(model.CategoryId);
            return new Question
            {
                QuestionTitle = model.QuestionTitle,
                QuestionContent = model.QuestionContent,
                QuestionCreated = DateTime.Now,
                User = user,
                Category = category
            };
        }

    }
}