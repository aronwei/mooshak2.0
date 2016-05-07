using System;
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
        public void AddAssignment(Assignment newAssignment)
        {
            _db.Assignments.Add(newAssignment);
            _db.SaveChanges();
        }
        public List<AssignmentViewModel> GetAssignmentsInCourse(int courseID)
        {
            //TODO:
            return null;
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
    }
}