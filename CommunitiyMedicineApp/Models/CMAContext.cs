using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CommunitiyMedicineApp.Models.Entity;

namespace CommunitiyMedicineApp.Models
{
    public class CMAContext:DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Thana> Thanas { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<SendMedicine> SendMedicines { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public CMAContext()
        {
            
        }

    }
}