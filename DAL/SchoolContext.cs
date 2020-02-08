using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        //this is the constructor of the database class. It names the database shool context as the string "String Context"
        public SchoolContext() : base("SchoolContext")
        {
      
        }
        //Below are the models we created in this class. These are the classes Entity Framework will check to see if they changed. 
        //If these base models change the default behavior for entity framework is to drop the tabes in the database and then create new ones with the updated structure
        
        public DbSet<Student> Students{ get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        //Below is a method that tells entity framework to avoid one its default behaviors and not to change the model names in C# into plural form when they are creating the tables
        //There are a bunch of default behaviors you can turn on or off to be sure EF behaves the way you need it to but for now this will be the only behavior we will change.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //This is the context that the EF will work with but now we need to initialize the database and set up some test data. 
        //We do this in a class specifically created to initialize or rather start the database. 
    }
}