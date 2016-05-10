﻿using System;
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
            var course = _db.Courses.SingleOrDefault(x => x.ID == courseID);
            if (course == null) return null;

            return new CourseViewModel() { ID = course.ID, Name = course.Name, Students = course.Students.ToList() };
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
            /*
            List<UserViewModel> students = new List<UserViewModel>();
            var b = (from a in _db.CourseAndUser
                     where (a.CourseID == ThisCourseID)
                     select a).ToList();
            List<int> idlist = new List<int>();
            foreach (var x in b)
            {
                idlist.Add(x.UserID);
            }*/
            /*foreach(var x in idlist)
            {
                var y = from a in _db.
            }*/


            //students.Sort((x, y) => string.Compare(x.Name, y.Name));
            return null;//students;

        }

        public List<ApplicationUser> GetStudentsByCourseID(int courseID)
        {
            var course = (from courses in _db.Courses where courses.ID == courseID select courses).SingleOrDefault();
            return course.Students.ToList();
        }

        public void AddStudentToCourse(int courseId, string userId)
        {
            ApplicationUser studentToAdd = (from student in _db.Users where student.Id == userId select student).SingleOrDefault();
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

    
