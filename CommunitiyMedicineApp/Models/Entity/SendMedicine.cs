using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models.Entity
{
    public class SendMedicine
    {
        public int Id { get; set; }
        [DisplayName("District")]
        public int DistrictId { get; set; }
        public virtual List<District> Districts { get; set; }
        [DisplayName("Thana")]
        public int ThanaId { get; set; }
        public virtual List<Thana> Thanas { get; set; }
        [DisplayName("Center")]
        public int CenterId { get; set; }
        public virtual List<Center> Centers { get; set; }
        [Required]
        [DisplayName("Medicine")]
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public List<Medicine> Medicines { get; set; }
        [Required(ErrorMessage = "Provide Quantity")]
        public double Quantity { get; set; }
    }
}