namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCenterIdInTreatment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatments", "CenterId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Treatments", "CenterId");
        }
    }
}
