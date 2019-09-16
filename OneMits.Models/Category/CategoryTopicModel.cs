using OneMits.Models.Category;
using OneMits.Models.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Category
{
    public class CategoryTopicModel
    {
        public CategoryListingModel Forum { get; set; }
        public IEnumerable<QuestionListingModel> Questions { get; set; }
        public string SearchQuery { get; set; }
    }
}
