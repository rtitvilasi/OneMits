﻿
using System;
using System.Collections.Generic;
using System.Text;
using OneMits.Models.Question;

namespace OneMits.Models.Category
{
    public class CategoryTopicModel
    {
        public CategoryListingModel Forum { get; set; }
        public IEnumerable<QuestionListingModel> Questions { get; set; }
        public string SearchQuery { get; set; }
    }
}
