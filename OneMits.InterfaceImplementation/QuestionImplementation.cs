using Microsoft.EntityFrameworkCore;
using OneMits.Data;
using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.InterfaceImplementation
{
    public class QuestionImplementation : IQuestion
    {
        private readonly ApplicationDbContext _context;

        public QuestionImplementation(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Add(Question question)
        {
            throw new NotImplementedException();
        }

        public Task AddReply(Answer answer)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Questionid)
        {
            throw new NotImplementedException();
        }

        public Task EditQuestionContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Questions
                 .Include(question => question.User)
                 .Include(question => question.Answers).ThenInclude(answer => answer.User)
                 .Include(question => question.Category);
        }

        public Question GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetFilteredQuestions(Category category, string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetFilteredQuestions(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetLatestQuestions(int n)
        {
            return GetAll().OrderByDescending(question => question.QuestionCreated).Take(n);
        }

        public IEnumerable<Question> GetMostResponseQuestions(int n)
        {
            return GetAll().OrderByDescending(question => question.Answers.Count()).Take(n);
        }

        public IEnumerable<Question> GetPopularQuestions(int n)
        {
            return GetAll().OrderByDescending(question => question.QuestionCreated).Take(n);
        }

        public IEnumerable<Question> GetPriorityQuestions(int n)
        {
            return GetAll().OrderByDescending(question => question.QuestionCreated).Take(n);
        }

        public IEnumerable<Question> GetQuestionsByCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
