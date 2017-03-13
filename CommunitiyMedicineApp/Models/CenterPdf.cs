using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunitiyMedicineApp.Migrations;

namespace CommunitiyMedicineApp.Models
{
    public class CenterPdf
    {
        public int Id { get; set; }
        public string CenterName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int ThanaId { get; set; }
        public string ThanaName { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}