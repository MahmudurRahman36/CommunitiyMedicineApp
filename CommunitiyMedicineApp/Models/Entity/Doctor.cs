using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models.Entity
{
    public class Doctor
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public List<Center> Centers { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string Specialisation { get; set; }
    }
}