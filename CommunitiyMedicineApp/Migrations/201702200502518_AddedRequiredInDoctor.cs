namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredInDoctor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Degree", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Specialisation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "Specialisation", c => c.String());
            AlterColumn("dbo.Doctors", "Degree", c => c.String());
            AlterColumn("dbo.Doctors", "Name", c => c.String());
        }
    }
}
