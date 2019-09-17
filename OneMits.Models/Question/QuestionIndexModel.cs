using OneMits.Models.Answer;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Question
{
    public class QuestionIndexModel
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public DateTime QuestionCreated { get; set; }
        public string QuestionContent { get; set; }
        public bool IsAuthorAdmin { get; set; }

        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }

        public IEnumerable<AnswerModel> Answers { get; set; }
    }
}
