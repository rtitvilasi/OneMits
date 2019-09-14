using OneMits.Data;
using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.InterfaceImplementation
{
    public class QuestionImplementation : IQuestion
    {
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestionsByCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
