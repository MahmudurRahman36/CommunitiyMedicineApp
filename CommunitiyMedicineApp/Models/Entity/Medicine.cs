using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models.Entity
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Generic Name")]       
       // [Column(TypeName = "varchar")]
       // [StringLength(50, MinimumLength = 2)]
        public string GenericName { get; set; }
        [Required]
        [DisplayName("Mg/Ml")]
        public double MgMl { get; set; }
    }
}