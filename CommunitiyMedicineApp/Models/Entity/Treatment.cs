using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime DateTime { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
        [Required]
        public int DiseaseId { get; set; }
        public virtual List<Disease> Diseases { get; set; }
        [Required]
        public int MedicineId { get; set; }
        public virtual List<Medicine> Medicines { get; set; }
        [Required]
        public string Dose { get; set; }
        [Required]
        public int DoseTime { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public int CenterId { get; set; }
        public int NumberTimeServiceGiven { get; set; }
    }
}