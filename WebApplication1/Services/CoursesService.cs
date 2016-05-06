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
        }
        public CourseViewModel GetCourseByID(int courseID)
        {
            var courses = _db.Courses.SingleOrDefault(x => x.ID == courseID);
            var ViewModel = new CourseViewModel();
            return null;
         
        }
    }
}