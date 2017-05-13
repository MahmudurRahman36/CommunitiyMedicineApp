using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CommunitiyMedicineApp.Models.Entity;

namespace CommunitiyMedicineApp.Models.Entity
{
    public class Treatment
    {
        public int Id { get; set; }
        [Required]
        public string VoterIdNo { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Age { set; get; }
        [Required]
        public string Observation { set; get; }

        [Required]
        [Column(TypeName = "datetime")]
        [DataType(DataType.Date)]
        [DisplayName("Today's Date")] 
        public DateTime TodayDateTime { get; set; }

        [Required]
        [DisplayName("Doctor")]
        public int DoctorId { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
        [Required]
        [DisplayName("Disease")]
        public int DiseaseId { get; set; }
        public virtual List<Disease> Diseases { get; set; }
        [Required]
        public int MedicineId { get; set; }
        [DisplayName("Medicine")]
        public virtual List<Medicine> Medicines { get; set; }
        [Required]
        public string Dose { get; set; }
        [Required]
        [DisplayName("Dose Time")]
        public int DoseTime { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public int CenterId { get; set; }
        [DisplayName("Number Time Service Given")]
        public int NumberTimeServiceGiven { get; set; }
    }
}