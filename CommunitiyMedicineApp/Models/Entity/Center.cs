using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models.Entity
{
    public class Center
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Center Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "District")]
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
        [Required]
        [Display(Name = "Thana")]
        public int ThanaId { get; set; }
        public virtual Thana Thana { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}