namespace HR_Department.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accountings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Workload = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DepartmentId = c.Int(nullable: false),
                    HR_DepartmentId = c.Int(nullable: false),
                    AccountingId = c.Int(nullable: false),
                    WorkBookId = c.Int(nullable: false),
                    PassportId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accountings", t => t.AccountingId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.HR_Department", t => t.HR_DepartmentId, cascadeDelete: true)
                //.ForeignKey("dbo.Passport", t => t.PassportId, cascadeDelete: true)
                //.ForeignKey("dbo.WorkBook", t => t.WorkBookId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.HR_DepartmentId)
                .Index(t => t.AccountingId);
                //.Index(t => t.PassportId)
                //.Index(t => t.WorkBookId);

            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Position = c.String(),
                        Rank = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HR_Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VacationDates = c.DateTime(nullable: false),
                        DateStartContract = c.DateTime(nullable: false),
                        DateEndContract = c.DateTime(nullable: false),
                        DateStartWorkUniversity = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Passports",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        FirstName = c.String(),
                        MidleName = c.String(),
                        LastName = c.String(),
                        NumberAndSeries = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.WorkBooks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        numberWorkBook = c.Int(nullable: false),
                        DateIssue = c.DateTime(nullable: false),
                        WorkExperience = c.Int(nullable: false),
                        NumberTaxpayer = c.Int(nullable: false),
                        PensionNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Decrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberDecree = c.Int(nullable: false),
                        DateBegin = c.DateTime(nullable: false),
                        Action = c.String(),
                        WorkBook_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkBooks", t => t.WorkBook_Id)
                .Index(t => t.WorkBook_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkBooks", "Id", "dbo.Employees");
            DropForeignKey("dbo.Decrees", "WorkBook_Id", "dbo.WorkBooks");
            DropForeignKey("dbo.Passports", "Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "HR_DepartmentId", "dbo.HR_Department");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "AccountingId", "dbo.Accountings");
            DropIndex("dbo.Decrees", new[] { "WorkBook_Id" });
            DropIndex("dbo.WorkBooks", new[] { "Id" });
            DropIndex("dbo.Passports", new[] { "Id" });
            DropIndex("dbo.Employees", new[] { "AccountingId" });
            DropIndex("dbo.Employees", new[] { "HR_DepartmentId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropTable("dbo.Decrees");
            DropTable("dbo.WorkBooks");
            DropTable("dbo.Passports");
            DropTable("dbo.HR_Department");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Accountings");
        }
    }
}
