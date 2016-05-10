using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services
{
    public class UserService
    {
        private ApplicationDbContext _db;

        public UserService()
        {
            _db = new ApplicationDbContext();
        }

        /*public List<ApplicationUser> GetAllUsers()
        {
            return _db.Users.ToList();
        }*/

        //Virkni ekki komið í lag
        public List<Course> GetCoursesByUserID(string userID)
        {
            var user = (from users in _db.Users where users.Id == userID select users).SingleOrDefault();
            return user.Courses.ToList();
            
        }

        public List<ApplicationUser> GetAllUsers()
        {
            List<ApplicationUser> skil = new List<ApplicationUser>();
            var users = _db.Users.ToList();
            foreach (ApplicationUser x in users)
            {
                var temp = new ApplicationUser();
                temp.Name = x.Name;
                temp.SSN = x.SSN;
                temp.UserName = x.UserName;
                temp.Id = x.Id;
                
                skil.Add(temp);
            }
            skil.Sort((x, y) => string.Compare(x.Name, y.Name));
            return skil;
        }
    }
}