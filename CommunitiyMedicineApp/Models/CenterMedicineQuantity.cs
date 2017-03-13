using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunitiyMedicineApp.Models
{
    public class CenterMedicineQuantity
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public double Quantity { get; set; }
    }
}