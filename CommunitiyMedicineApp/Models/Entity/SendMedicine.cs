using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models.Entity
{
    public class SendMedicine
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public virtual List<District> Districts { get; set; }
        public int ThanaId { get; set; }
        public virtual List<Thana> Thanas { get; set; }
        public int CenterId { get; set; }
        public virtual List<Center> Centers { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public List<Medicine> Medicines { get; set; }
        public double Quantity { get; set; }
    }
}