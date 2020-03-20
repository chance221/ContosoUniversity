using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        [Display(Name="Enrollment ID")]
        public int EnrollmentID { get; set; }


        [Index]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }


        [Index]
        [Display(Name="Student ID")]
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }


}