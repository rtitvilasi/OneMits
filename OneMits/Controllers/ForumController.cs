using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneMits.Data.Models;
using OneMits.InterfaceImplementation;
using OneMits.Models.Category;
using OneMits.Models.Question;

namespace OneMits.Controllers
{
    public class ForumController : Controller
    {
        private readonly QuestionImplementation _questionImplementation;
        private readonly CategoryImplementation _categoryImplementation;
        public ForumController(QuestionImplementation questionImplementation, CategoryImplementation categoryImplementation)
        {
            _questionImplementation = questionImplementation;
            _categoryImplementation = categoryImplementation;
        }
        public IActionResult Index()
        {
            var forums = _categoryImplementation.GetAll().Select(forum => new CategoryListingModel
            {
                CategoryId = forum.CategoryId,
                CategoryTitle = forum.CategoryTitle,
                CategoryDescription = forum.CategoryDescription,
            });
            var model = new CategoryIndexModel
            {
                QuestionList = forums
            };
            return View(model);
        }

        public IActionResult Topic(int id, string searchQuery)
        {
            var forum = _questionImplementation.GetById(id);
            var posts = new List<Question>();

            posts = _questionImplementation.GetFilteredQuestions(forum, searchQuery).ToList();

            var QuestionListings = posts.Select(question => new QuestionListingModel
            {
                QuestionId = question.QuestionId,
                AuthorName = question.User.UserName,
                QuestionTitle = question.QuestionTitle,
                QuestionCreated = question.QuestionCreated.ToString(),
                AnswerCount = question.Answers.Count(),
                Category = BuildForumListing(question)
            });

            var model = new CategoryTopicModel
            {
                Questions = QuestionListings,
                Forum = BuildForumListing(forum)
            };

            return View(model);
        }

    }
}