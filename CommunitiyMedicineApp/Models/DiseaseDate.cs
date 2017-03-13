using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models
{
    public class DiseaseDate
    {
        public int DiseaseId { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}