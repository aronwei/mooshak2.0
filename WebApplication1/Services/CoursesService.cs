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
            foreach (Course x in courses)
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
            foreach (var x in b)
            {
                idlist.Add(x.UserID);
            }
            /*foreach(var x in idlist)
            {
                var y = from a in _db.
            }*/


            students.Sort((x, y) => string.Compare(x.Name, y.Name));
            return students;

        }

        public List<UserViewModel> GetStudentsByCourseID(int courseID)
        {
            List<UserViewModel> students = new List<UserViewModel>();
             var studentsInCourse = (from student in _db.Students
                           where student.Courses.Count(x => x.ID == courseID) > 0
                           select student).ToList();
            foreach(Student x in studentsInCourse)
            {
                var temp = new UserViewModel();
                temp.ID = x.ID;
                temp.Name = x.Name;
                students.Add(temp);

            }

            return students;
        }

        public void AddStudentToCourse(int courseId, int studentId)
        {
            Student studentToAdd = (from student in _db.Students where student.ID == studentId select student).SingleOrDefault();
            Course courseToAdd = (from course in _db.Courses where course.ID == courseId select course).SingleOrDefault();
            if (studentToAdd != null && courseToAdd != null)
            {
                if (studentToAdd.Courses.Where(x => x.ID == courseId).Count() == 0)
                {
                    studentToAdd.Courses.Add(courseToAdd);
                    _db.SaveChanges();
                }
            }
        }
    }
}

    
