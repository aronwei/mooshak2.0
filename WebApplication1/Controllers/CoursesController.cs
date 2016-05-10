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
    [Authorize(Roles = "Administrators")]
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

        public ActionResult ViewCourses()
        {
            CoursesService coursesservice = new CoursesService();
            var model = coursesservice.GetAllCourses();
            return View(model);

        }

        [HttpGet]
        [Route("Courses/ViewCourseDetails/{courseID}")]
        public ActionResult ViewCourseDetails(int? courseID)
        {
            CoursesService cs =  new CoursesService();
            AssignmentsService ass = new AssignmentsService();

            CourseViewModel model = cs.GetCourseByID(courseID.Value);
            model.Assignments = ass.GetAssignmentsByCourseID(courseID.Value);

            return View(model);
        }

        [HttpGet]
        [Route("Courses/AddStudentsToCourse/{courseID}")]
        public ActionResult AddStudentsToCourse(int courseID)
        {
            AddStudentToCourseViewModel model = new AddStudentToCourseViewModel();
            model.CourseID = courseID;

            UserService userService = new UserService();
            model.AvailableStudents = userService.GetAllUsers().Select(x=>new SelectListItem() { Value = x.Id, Text = x.UserName }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddStudentsToCourse(AddStudentToCourseViewModel model)
        {
            CoursesService courseService = new CoursesService();

            courseService.AddStudentToCourse(model.CourseID, model.UserID);

            return RedirectToAction("ViewCourseDetails", new { courseID = model.CourseID });
        }
   
        [HttpGet]
        [Route("Courses/AddAssignmentToCourse/{courseID}")]
        public ActionResult AddAssignmentsToCourse(int courseID)
        {
            AddAssignmentToCourseViewModel model = new AddAssignmentToCourseViewModel();
            model.CourseID = courseID;

            AssignmentsService assigmentService = new AssignmentsService();
            model.AvailableAssignments = assigmentService.GetAllAssignments().Select(x => new SelectListItem() { Value = x.ID.ToString(), Text = x.Title }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddAssignmentsToCourse(AddAssignmentToCourseViewModel model)
        {
            CoursesService assignmentService = new CoursesService();

            assignmentService.AddAssignmentToCourse(model.CourseID, model.AssignmentID);

            return RedirectToAction("ViewCourseDetails", new { courseID = model.CourseID });
        }
    }
}