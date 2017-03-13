using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models.Entity
{
    public class Thana
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
    }
}