using OneMits.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Search
{
    public class SearchModel : LayoutBaseModel
    {
        public IEnumerable<QuestionListingModel> Questions { get; set; }
        
        public bool EmptySearchResults { get; set; }
    }
}
