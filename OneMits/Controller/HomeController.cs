using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data.Models;
using OneMits.InterfaceImplementation;
using OneMits.Models;
using OneMits.Models.Category;
using OneMits.Models.Home;
using OneMits.Models.Question;

namespace OneMits.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuestionImplementation _questionImplementation;

        public HomeController(QuestionImplementation questionImplementation)
        {
            _questionImplementation = questionImplementation;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndex();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndex()
        {
            var recentQuestion = _questionImplementation.GetLatestQuestions(10);
            var popularQuestion = _questionImplementation.GetLatestQuestions(10);
            var mostResponseQuestion = _questionImplementation.GetLatestQuestions(10);
            var priorityQuestion = _questionImplementation.GetLatestQuestions(10);
            var recentQuestions = recentQuestion.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                AuthorName = question.User.UserName,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                Category = GetCategoryListingForQuestion(question)
            });
            var popularQuestions = recentQuestion.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                AuthorName = question.User.UserName,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                Category = GetCategoryListingForQuestion(question)
            });
            var mostResponseQuestions = recentQuestion.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                AuthorName = question.User.UserName,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                Category = GetCategoryListingForQuestion(question)
            });
            var priorityQuestions = recentQuestion.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                AuthorName = question.User.UserName,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                Category = GetCategoryListingForQuestion(question)
            });
            return new HomeIndexModel
            {
                RecentQuestion = recentQuestions,
                PopularQuestion = popularQuestions,
                MostResponseQuestion = mostResponseQuestions,
                PriorityQuestion = priorityQuestions,
                searchQuery = " "
            };
        }

        private CategoryListingModel GetCategoryListingForQuestion(Question question)
        {
            var category = question.Category;
            return new CategoryListingModel
            {
                CategoryId = category.CategoryId,
                CategoryTitle = category.CategoryTitle,
                CategoryImageUrl = category.CategoryImageUrl
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
