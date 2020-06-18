namespace HIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intital : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentRegistrations", "classid", c => c.Int(nullable: false));
            DropColumn("dbo.StudentSubjects", "classid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentSubjects", "classid", c => c.Int(nullable: false));
            DropColumn("dbo.StudentRegistrations", "classid");
        }
    }
}
