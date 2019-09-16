using OneMits.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Category
{
    public class CategoryIndexModel
    {
        public IEnumerable<CategoryListingModel> QuestionList { get; set; }
    }
}
