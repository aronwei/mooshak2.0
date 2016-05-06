using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models.Entities
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ApplicationUser> Teachers { get; set; }
        public List<ApplicationUser> Students { get; set; }

        [Authorize("Admin")]
        public void AddStudent(ApplicationUser student)
        {
            Students.Add(student);
        }
        [Authorize("Admin")]
        public void AddTeachers(ApplicationUser teacher)
        {
            Teachers.Add(teacher);
        }
    }
}