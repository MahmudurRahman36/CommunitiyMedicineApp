using CommunitiyMedicineApp.Models.Entity;

namespace CommunitiyMedicineApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CommunitiyMedicineApp.Models.CMAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CommunitiyMedicineApp.Models.CMAContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Medicines.AddOrUpdate(
            //  p => p.GenericName,
            //  new Medicine() { GenericName = "Paracitamal", MgMl = 500 },
            //  new Medicine() { GenericName = "Salaien", MgMl = 250 },
            //  new Medicine() { GenericName = "Renitidine", MgMl = 750 }
            //);
            //context.Diseases.AddOrUpdate(
            //  p => p.Name,
            //  new Disease() { Name = "Fever", Description = "Very Bad", PDrugs = "Pracitamal", TProcedure = "Take Rest" },
            //  new Disease() { Name = "Gastic", Description = "Very Very Bad", PDrugs = "Renitidine", TProcedure = "Take Rest" },
            //  new Disease() { Name = "Diearia", Description = "Very Bad", PDrugs = "Salaien", TProcedure = "Take Rest" },
            //  new Disease() { Name = "Cold", Description = "Bad", PDrugs = "Pracitamal", TProcedure = "Take Rest" },
            //  new Disease() { Name = "Sleepe", Description = "Good", PDrugs = "Pracitamal", TProcedure = "Do not Take Rest" }
            //);
            //context.Districts.AddOrUpdate(
            //  p => p.Name,
            //  new District() { Name = "Dhaka", Population = 2000000 },
            //  new District() { Name = "Rajshahi", Population = 12000 },
            //  new District() { Name = "Kustia", Population = 10000 }
            //);
            //context.Thanas.AddOrUpdate(
            //  p => p.Name,
            //  new Thana() { Name = "Mirpur", DistrictId = 1 },
            //  new Thana() { Name = "Uttara", DistrictId = 1 },
            //  new Thana() { Name = "Baneshor", DistrictId = 2 },
            //  new Thana() { Name = "Sharda", DistrictId = 2 },
            //  new Thana() { Name = "Satarpara", DistrictId = 3 },
            //  new Thana() { Name = "Alamdanga", DistrictId = 3 }
            //);
            //context.Centers.AddOrUpdate(
            //  p => p.Name,
            //  new Center() { Name = "Mirpur-0", DistrictId = 1, ThanaId = 1, Code = "Dha-Mir-0", Password = "12345" },
            //  new Center() { Name = "Mirpur-1", DistrictId = 1, ThanaId = 1, Code = "Dha-Mir-1", Password = "12345" },
            //  new Center() { Name = "Sharda-0", DistrictId = 2, ThanaId = 4, Code = "Raj-Sha-0", Password = "12345" },
            //  new Center() { Name = "Sharda-1", DistrictId = 2, ThanaId = 4, Code = "Raj-Sha-0", Password = "12345" },
            //  new Center() { Name = "Satarpara", DistrictId = 3, ThanaId = 5, Code = "Kus-Sat-0", Password = "12345" },
            //  new Center() { Name = "Satarpara", DistrictId = 3, ThanaId = 5, Code = "Kus-Sat-1", Password = "12345" }
            //);
            //context.SendMedicines.AddOrUpdate(
            //  p => p.CenterId,
            //  new SendMedicine() { DistrictId = 1, ThanaId = 1, CenterId = 6, MedicineId = 1, Quantity = 5 },
            //  new SendMedicine() { DistrictId = 1, ThanaId = 1, CenterId = 6, MedicineId = 2, Quantity = 10 },
            //  new SendMedicine() { DistrictId = 1, ThanaId = 1, CenterId = 7, MedicineId = 1, Quantity = 20 },
            //  new SendMedicine() { DistrictId = 2, ThanaId = 4, CenterId = 8, MedicineId = 1, Quantity = 30 },
            //  new SendMedicine() { DistrictId = 2, ThanaId = 4, CenterId = 8, MedicineId = 2, Quantity = 40 },
            //  new SendMedicine() { DistrictId = 2, ThanaId = 4, CenterId = 9, MedicineId = 2, Quantity = 50 }
            //);
            //context.Doctors.AddOrUpdate(
            //  p => p.Name,
            //  new Doctor() { CenterId = 6, Name = "Mahmud", Degree = "None", Specialisation = "None" },
            //  new Doctor() { CenterId = 6, Name = "Rajan", Degree = "All", Specialisation = "All" },
            //  new Doctor() { CenterId = 8, Name = "Porag", Degree = "MBBS", Specialisation = "Heart" }
            //);
        }
    }
}
