using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebApplication1.Models.ViewModels
{
   public class CourseViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
    }

    public class ViewCorseViewModel
    {
        public string Name { get; set; }
    }
}
