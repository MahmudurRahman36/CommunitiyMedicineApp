namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameAgeAddressInTreatment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatments", "Name", c => c.String());
            AddColumn("dbo.Treatments", "Address", c => c.String());
            AddColumn("dbo.Treatments", "Age", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Treatments", "Age");
            DropColumn("dbo.Treatments", "Address");
            DropColumn("dbo.Treatments", "Name");
        }
    }
}
