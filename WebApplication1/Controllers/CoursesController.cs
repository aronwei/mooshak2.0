using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CoursesController : Controller
    {
        //
        // GET: /Courses/
        public ActionResult AddCourse()
        {
            CourseViewModel model = new CourseViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course newcourse = new Course();
                newcourse.Name = model.Name;
                CoursesService coursedb = new CoursesService();
                coursedb.AddCourseToDB(newcourse);
                
               return RedirectToAction("AddCourse");
           }
               
           return View(model);
        }


	}
}