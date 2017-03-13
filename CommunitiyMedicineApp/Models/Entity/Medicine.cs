using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models.Entity
{
    public class Medicine
    {
        public int Id { get; set; }
        [Required]
        public string GenericName { get; set; }
        [Required]
        public double MgMl { get; set; }
    }
}