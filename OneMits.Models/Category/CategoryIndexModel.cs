using OneMits.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Category
{
    public class CategoryIndexModel : LayoutBaseModel
    {
        public IEnumerable<CategoryListingModel> CategoryList { get; set; }
        public CategoryListingModel Category { get; set; }
    }
}
