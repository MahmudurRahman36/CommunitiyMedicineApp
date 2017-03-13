namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMedicineInSendMedicine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SendMedicines", "MedicineName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SendMedicines", "MedicineName");
        }
    }
}
