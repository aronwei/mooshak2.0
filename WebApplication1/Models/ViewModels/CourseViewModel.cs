using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models.ViewModels
{
    public class CourseViewModel
    {

        public int ID { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string Name { get; set; }


    }
}