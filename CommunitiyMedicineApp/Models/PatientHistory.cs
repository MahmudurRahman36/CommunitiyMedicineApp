using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models
{
    public class PatientHistory
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public string CenterName { get; set; }
        public int ThanaId { get; set; }
        public string ThanaName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string DateTime { get; set; }
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public double Quantity { get; set; }
        public string Note { get; set; }

    }
}