namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTreatment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoterIdNo = c.Int(nullable: false),
                        Observation = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        DiseaseId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        Dose = c.String(),
                        DoseTime = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Diseases", "Treatment_Id", c => c.Int());
            AddColumn("dbo.Doctors", "Treatment_Id", c => c.Int());
            AddColumn("dbo.Medicines", "Treatment_Id", c => c.Int());
            CreateIndex("dbo.Diseases", "Treatment_Id");
            CreateIndex("dbo.Doctors", "Treatment_Id");
            CreateIndex("dbo.Medicines", "Treatment_Id");
            AddForeignKey("dbo.Diseases", "Treatment_Id", "dbo.Treatments", "Id");
            AddForeignKey("dbo.Doctors", "Treatment_Id", "dbo.Treatments", "Id");
            AddForeignKey("dbo.Medicines", "Treatment_Id", "dbo.Treatments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicines", "Treatment_Id", "dbo.Treatments");
            DropForeignKey("dbo.Doctors", "Treatment_Id", "dbo.Treatments");
            DropForeignKey("dbo.Diseases", "Treatment_Id", "dbo.Treatments");
            DropIndex("dbo.Medicines", new[] { "Treatment_Id" });
            DropIndex("dbo.Doctors", new[] { "Treatment_Id" });
            DropIndex("dbo.Diseases", new[] { "Treatment_Id" });
            DropColumn("dbo.Medicines", "Treatment_Id");
            DropColumn("dbo.Doctors", "Treatment_Id");
            DropColumn("dbo.Diseases", "Treatment_Id");
            DropTable("dbo.Treatments");
        }
    }
}
