namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DontKnowWhatChanaged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Treatments", "Observation", c => c.String(nullable: false));
            AlterColumn("dbo.Treatments", "DateTime", c => c.String(nullable: false));
            AlterColumn("dbo.Treatments", "Dose", c => c.String(nullable: false));
            AlterColumn("dbo.Treatments", "Note", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Treatments", "Note", c => c.String());
            AlterColumn("dbo.Treatments", "Dose", c => c.String());
            AlterColumn("dbo.Treatments", "DateTime", c => c.String());
            AlterColumn("dbo.Treatments", "Observation", c => c.String());
        }
    }
}
