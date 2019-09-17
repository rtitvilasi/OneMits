using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.Data
{
    public interface IQuestion
    {
        Question GetById(int id);
        IEnumerable<Question> GetAll();
        IEnumerable<Question> GetFilteredQuestions(Category category, string searchQuery);
        IEnumerable<Question> GetFilteredQuestions(string searchQuery);
        IEnumerable<Question> GetQuestionsByCategory(int id);
        IEnumerable<Question> GetLatestQuestions(int n);
        IEnumerable<Question> GetPopularQuestions(int n);
        IEnumerable<Question> GetMostResponseQuestions(int n);
        IEnumerable<Question> GetPriorityQuestions(int n);

        Task Add(Question question);
        Task Delete(int Questionid);
        Task EditQuestionContent(int id, string newContent);
        Task AddAnswer(Answer answer);
    }
}
