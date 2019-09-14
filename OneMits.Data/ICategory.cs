using OneMits.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneMits.Data
{
    public interface ICategory
    {
        Category GetById(int id);
        IEnumerable<Category> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        Task Create(Category category);
        Task Delete(int categoryid);
        Task UpdateForumTitle(int categoryid, string newCategoryTitle);
        Task UpdateForumDescription(int categoryid, string newCategoryDescription);
    }
}
