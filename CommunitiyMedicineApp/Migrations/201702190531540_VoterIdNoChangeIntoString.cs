namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoterIdNoChangeIntoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Treatments", "VoterIdNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Treatments", "VoterIdNo", c => c.Long(nullable: false));
        }
    }
}
