using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models.Entity
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
    }
}