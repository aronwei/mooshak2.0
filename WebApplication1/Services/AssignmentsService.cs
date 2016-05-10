﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;


namespace WebApplication1.Services
{
    public class AssignmentsService
    {
        private ApplicationDbContext _db;
        public AssignmentsService()
        {
            _db = new ApplicationDbContext();
        }
        public void AddAssignmentToCourse(AssignmentViewModel model)
        {
            Assignment newAssignment = new Assignment();
            newAssignment.Title = model.Title;
            newAssignment.Descriptin = model.Description;
            newAssignment.Start = model.Start;
            newAssignment.End = model.End;
            _db.Assignments.Add(newAssignment);
            _db.SaveChanges();
        }



       /* public void AddStudentToCourse(int courseId, string userId)
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
        }*/
        public List<Assignment> GetAssignmentsByCourseID(int courseID)
        {
            var course = (from courses in _db.Courses where courses.ID == courseID select courses).SingleOrDefault();
            return course.Assignments.ToList();
        }

        public AssignmentViewModel GetAssignmentByID(int assignmentID)
        {
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == assignmentID);
            if (assignment == null)
            {
                //TODO: kasta villu!
            }

            var milestones = _db.Milestones
                .Where(x => x.AssignmentID == assignmentID)
                .Select(x => new AssignmentMilestoneViewModel
                {
                    Title = x.Title
                })
                .ToList();

            var viewModel = new AssignmentViewModel
            {
                Title = assignment.Title,
                Milestones = milestones
            };

            return null;
        }
        public List<Assignment> GetAllAssignments()
        {
            return _db.Assignments.ToList();
        }
    }
}