using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data;
using OneMits.Data.Models;
using OneMits.Models.Category;
using OneMits.Models.Question;
using OneMits.Models.Search;

namespace OneMits.Controllers
{
    public class SearchController : Controller
    {
        private readonly IQuestion _questionImplementation;
        private IEnumerable<QuestionListingModel> postListings;

        public SearchController(IQuestion questionImplementation)
        {
            _questionImplementation = questionImplementation;
        }

        public IActionResult Result(string searchQuery)
        {
            var questions = _questionImplementation.GetFilteredQuestions(searchQuery);
            var areNoResults = (!string.IsNullOrEmpty(searchQuery) && !questions.Any());

            var questionListingModel = questions.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                AuthorName = question.User.UserName,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                Category = BuildForumListing(question)
            });
            var model = new SearchModel
            {
                Questions = questionListingModel,
                SearchQuery = searchQuery,
                EmptySearchResults = areNoResults
            };
            return View(model);
        }

        private CategoryListingModel BuildForumListing(Question question)
        {
            var catogory = question.Category;
            return new CategoryListingModel
            {
                CategoryId = catogory.CategoryId,
                CategoryTitle = catogory.CategoryTitle,
                CategoryImageUrl = catogory.CategoryImageUrl,
                CategoryDescription = catogory.CategoryDescription
            };

        }

        public IActionResult User()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Result", new { searchQuery });
        }
    }
}