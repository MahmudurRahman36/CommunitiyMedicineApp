using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models
{
    public class DistrictWiseReport
    {
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
        public int TotalPatient { get; set; }
        public DateTime DateTime { get; set; }  
    }
}