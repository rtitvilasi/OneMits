using OneMits.Data;
using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneMits.InterfaceImplementation
{
    public class ApplicationUserImplementation : IApplicationUser
    {
        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserRating(string id, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
