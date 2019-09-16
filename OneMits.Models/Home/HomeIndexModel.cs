using OneMits.Models.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneMits.Models.Home
{
    public class HomeIndexModel
    {
        public string searchQuery { get; set; }
        public IEnumerable<ForumListingModel> RecentQuestion { get; set; }
        public IEnumerable<ForumListingModel> PopularQuestion { get; set; }
        public IEnumerable<ForumListingModel> MostResponseQuestion { get; set; }
        public IEnumerable<ForumListingModel> PriorityQuestion { get; set; }

    }
}
