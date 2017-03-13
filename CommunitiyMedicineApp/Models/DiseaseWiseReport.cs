using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models
{
    public class DiseaseWiseReport
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int TotalPatients { get; set; }
        public DateTime DateTime { get; set; }
        public double PercentageOfPopulation { get; set; }
    }
}