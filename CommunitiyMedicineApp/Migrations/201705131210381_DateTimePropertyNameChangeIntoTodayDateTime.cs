namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimePropertyNameChangeIntoTodayDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatments", "TodayDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Treatments", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Treatments", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Treatments", "TodayDateTime");
        }
    }
}
