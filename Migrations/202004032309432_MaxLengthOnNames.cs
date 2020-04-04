namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnNames : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentInfo", name: "FirstName", newName: "FirstMidName");
            RenameColumn(table: "dbo.StudentInfo", name: "DateEnrolled", newName: "EnrollmentDate");
            AlterColumn("dbo.StudentInfo", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.StudentInfo", "FirstMidName", c => c.String(maxLength: 50));
            DropColumn("dbo.StudentInfo", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentInfo", "Phone", c => c.String());
            AlterColumn("dbo.StudentInfo", "FirstMidName", c => c.String(maxLength: 20));
            AlterColumn("dbo.StudentInfo", "LastName", c => c.String(nullable: false, maxLength: 30));
            RenameColumn(table: "dbo.StudentInfo", name: "EnrollmentDate", newName: "DateEnrolled");
            RenameColumn(table: "dbo.StudentInfo", name: "FirstMidName", newName: "FirstName");
        }
    }
}
