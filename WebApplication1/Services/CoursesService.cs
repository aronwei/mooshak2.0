using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Services
{
    public class CoursesService
    {
        private ApplicationDbContext _db;
        public CoursesService()
        {
            _db = new ApplicationDbContext();
        }
        public void AddCourseToDB(Course newCourse)
        {
            _db.Courses.Add(newCourse);
            _db.SaveChanges();
        }
        public CourseViewModel GetCourseByID(int courseID)
        {
            var courses = _db.Courses.SingleOrDefault(x => x.ID == courseID);
            var ViewModel = new CourseViewModel();
            return null;
         
        }
        public List<CourseViewModel> GetAllCourses()
        {
            List<CourseViewModel> skil = new List<CourseViewModel>();
            var courses = _db.Courses.ToList();
            foreach(Course  x in courses)
            {
                var temp = new CourseViewModel();
                temp.Name = x.Name;
                temp.ID = x.ID;
                skil.Add(temp);
            }
            skil.Sort((x, y) => string.Compare(x.Name, y.Name));
            return skil;
        }
        public List<UserViewModel> GetStudentsInCourse(int ThisCourseID)
        {
            List<UserViewModel> students = new List<UserViewModel>();
            var b = (from a in _db.CourseAndUser
                    where (a.CourseID == ThisCourseID)
                    select a).ToList();
            List<int> idlist = new List<int>();
            foreach(var x in b)
            {
                idlist.Add(x.UserID);
            }
            foreach(var x in idlist)
            {
                var y = from a in _db.
            }


            students.Sort((x, y) => string.Compare(x.Name, y.Name));
            return students;
            
                         
            

        } 

    }
}