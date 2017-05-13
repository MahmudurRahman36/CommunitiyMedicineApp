using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models.Entity
{
    public class Disease
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Treatment Procedure")]
        public string TProcedure { get; set; }
        [Required]
        [DisplayName("Preference Drugs")]
        public string PDrugs { get; set; }
    }
}