using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Category
{
    public class AddCategoryModel
    {
        public string ForumTitle { get; set; }
        public string ForumDescription { get; set; }
    }
}
