using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class AssignmentViewModel
    {
        public string Title { get; set; }
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<AssignmentMilestoneViewModel> Milestones { get; set; }
    }
}