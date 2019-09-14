using OneMits.Data;
using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneMits.InterfaceImplementation
{
    public class CategoryImplementation : ICategory
    {
        public Task Create(Category category)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int categoryid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumDescription(int categoryid, string newCategoryDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int categoryid, string newCategoryTitle)
        {
            throw new NotImplementedException();
        }
    }
}
