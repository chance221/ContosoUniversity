using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {

        private SchoolContext db = new SchoolContext();


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }


        //This action method groups student enrollment by date and then displays the results (need to do this ofr the recipe tracker)
        public ActionResult EnrollmentStats()
        {
            IQueryable<EnrollmentDateGroup> data = from student in db.Students //get all the students from the database
                                                   group student by student.EnrollmentDate into dateGroup //group them by enrollment date
                                                   select new EnrollmentDateGroup() //create a new EnrollmentDateGroup Object that stores the results showing the enrollmentdate and the number of students enrolled on that date
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       StudentCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}