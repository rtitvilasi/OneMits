using Microsoft.AspNetCore.Http;
using OneMits.Data.Models;
using System;
using System.Threading.Tasks;

namespace OneMits.Data
{
    public class AddVisit
    {
        private IApplicationUser _applicationUserImplementation;
        private IHttpContextAccessor _accessor;
        private ApplicationDbContext _context;

        public AddVisit(IApplicationUser applicationUserImplementation, IHttpContextAccessor accessor, ApplicationDbContext context)
        {
            _applicationUserImplementation = applicationUserImplementation;
            _accessor = accessor;
            _context = context;
        }
        public async Task WebVisit()
        {
            var Visit = new Visits
            {
                Time = DateTime.Now,
                IpAddress = "HTTP",
            };
            await _applicationUserImplementation.AddVisit(Visit);
            await _context.SaveChangesAsync();
        }
    }
}
