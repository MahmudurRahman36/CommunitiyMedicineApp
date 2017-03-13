namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeEditedInTreatment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Treatments", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Treatments", "DateTime", c => c.String(nullable: false));
        }
    }
}
