using OneMits.Data;
using OneMits.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneMits.InterfaceImplementation
{
    public class ApplicationUserImplementation : IApplicationUser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserImplementation(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers;
        }

        public ApplicationUser GetById(string id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }

        public async Task UpdateUserRating(string userId, Type type)
        {
            var user = GetById(userId);
            user.Rating = CalculateUserRating(type, user.Rating);
            await _context.SaveChangesAsync();
        }
        private int CalculateUserRating(Type type, int userRating)
        {
            var inc = 0;
            if (type == typeof(Question))
                inc = 2;
            if (type == typeof(Answer))
                inc = 5;
            return userRating + inc;
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImageUrl = uri.AbsoluteUri;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddLoginTime(LoginTime loginTime)
        {
            _context.LoginTime.Add(loginTime);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<OtpTable> GetAllStudents()
        {
            return _context.OtpTable;
        }

        public OtpTable GetByEnrollment(string enrollmentNumber)
        {
            return _context.OtpTable.Where(student => student.EnrollmentNumber == enrollmentNumber)
                .FirstOrDefault();
        }

        public ApplicationUser GetByUserName(string userName)
        {
            return GetAll().FirstOrDefault(user => user.UserName == userName);
        }
    }
}
