using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CommunitiyMedicineApp.Models;
using CommunitiyMedicineApp.Models.Entity;

namespace CommunitiyMedicineApp.DAL
{
    public class HeadGateway
    {
        
        public List<Medicine> GetMedicineList()
        {
            CMAContext dbContext = new CMAContext();
            var existingMedicine = dbContext.Medicines.ToList();
            return existingMedicine;           
        }

        public bool SetMedicine(Medicine medicine)
        {
            CMAContext db = new CMAContext();
            db.Medicines.Add(medicine);
            int result = db.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsMedicineExist(string name, double mgMl)
        {
            CMAContext db = new CMAContext();
            var existingMedicine = db.Medicines.Any(c => c.GenericName == name && Math.Abs(c.MgMl - mgMl) < 0.001);
            return existingMedicine;
        }
        public List<Disease> GetDiseaseList()
        {
            CMAContext dbContext = new CMAContext();
            var existingDisease = dbContext.Diseases.ToList();
            return existingDisease;
        }
        public bool IsDiseaseExist(string name)
        {
            CMAContext db = new CMAContext();
            var existingDisease = db.Diseases.Any(c => c.Name == name);
            return existingDisease;
        }
        public bool SetDisease(Disease disease)
        {
            CMAContext db = new CMAContext();
            db.Diseases.Add(disease);
            int result = db.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<int> GetDiseaseIdList()
        {
            CMAContext dbContext = new CMAContext();
            var id = dbContext.Diseases.Select(c=>c.Id).ToList();
            return id;
        }
        public List<Center> GetCenterList()
        {
            CMAContext dbContext = new CMAContext();
            var existingCenter = dbContext.Centers.ToList();
            return existingCenter;
        }
        public List<District> GetDistrictList()
        {
            CMAContext dbContext = new CMAContext();
            var existingDistrict = dbContext.Districts.OrderBy(c => c.Name).ToList();
            return existingDistrict;
        }
        public string GetDistrictNameById(int districtId)
        {
            CMAContext dbContext = new CMAContext();
            var existingDistrict = dbContext.Districts.Where(c=>c.Id==districtId).Select(c=>c.Name).FirstOrDefault();
            return existingDistrict;
        }
        public List<Thana> GetThanaList()
        {
            CMAContext dbContext = new CMAContext();
            var existingThanas = dbContext.Thanas.ToList();
            return existingThanas;
        }
        public string GetThanaNameById(int thanaId)
        {
            CMAContext dbContext = new CMAContext();
            var existingThana = dbContext.Thanas.Where(c => c.Id == thanaId).Select(c => c.Name).FirstOrDefault();
            return existingThana;
        }
        public bool IsCenterExist(Center center)
        {
            CMAContext db = new CMAContext();
            var existingCenter = db.Centers.Any(p => p.Name == center.Name && p.ThanaId == center.ThanaId && p.DistrictId == center.DistrictId);
            return existingCenter;
        }
        public District GetDistrictNamebyId(int districtId)
        {
            CMAContext dbContext = new CMAContext();
            var existingDistrict = dbContext.Districts.Where(d => d.Id == districtId).AsNoTracking().FirstOrDefault();
            return existingDistrict;
        }

        public Thana GetThanaNamebyId(int thanaId)
        {
            CMAContext dbContext = new CMAContext();
            var existingThana = dbContext.Thanas.Where(d => d.Id == thanaId).AsNoTracking().FirstOrDefault();
            return existingThana;
        }
        public Center GetCenterNamebyId(int centerId)
        {
            CMAContext dbContext = new CMAContext();
            var existingCenter = dbContext.Centers.Where(d => d.Id == centerId).AsNoTracking().FirstOrDefault();
            return existingCenter;
        }
        public Disease GetDiseaseNamebyId(int diseaseId)
        {
            CMAContext dbContext = new CMAContext();
            var existingDisease = dbContext.Diseases.Where(d => d.Id == diseaseId).AsNoTracking().FirstOrDefault();
            return existingDisease;
        }
        public Medicine GetMedicineNamebyId(int medicineId)
        {
            CMAContext dbContext = new CMAContext();
            var existingMedicine = dbContext.Medicines.Where(d => d.Id == medicineId).AsNoTracking().FirstOrDefault();
            return existingMedicine;
        }
        public bool SetCenter(Center aCenter)
        {
            CMAContext db = new CMAContext();
            db.Centers.Add(aCenter);
            int result= db.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetLastCenterId(int thanaId,int districtId)
        {
            CMAContext db = new CMAContext();
            var existingCenter = db.Centers.Where(p => p.ThanaId == thanaId && p.DistrictId == districtId).AsNoTracking().LastOrDefault();
            if (existingCenter!=null)
            {
                return existingCenter.Id;
            }
            else
            {
                return 0;
            }
        }

        public int CountCenterNumber(int districtId,int thanaId)
        {
            CMAContext db = new CMAContext();
            var existingCenter = db.Centers.Where(p => p.ThanaId == thanaId && p.DistrictId == districtId).AsNoTracking().ToList();
            return existingCenter.Count;
        }
        public List<int> GetCenterListByDistrictId(int districtId)
        {
            CMAContext dbContext = new CMAContext();
            var centerList = dbContext.Centers.Where(c => c.DistrictId == districtId).AsNoTracking().Select(c => c.Id).ToList();
            return centerList;
        }
        public List<Treatment> GetTreatmentListByCenterId(int centerId,int diseaseId,DateTime fromDateTime,DateTime toDateTime )
        {
            CMAContext dbContext = new CMAContext();
            //var patientList = dbContext.Treatments.Where(c => c.CenterId == centerId).AsNoTracking().GroupBy(x => x.VoterIdNo).Select(x => x.First()).Select(x=>x.VoterIdNo).ToList();
            var treatmentList = dbContext.Treatments.Where(c => c.CenterId == centerId && c.DiseaseId == diseaseId && c.TodayDateTime>=fromDateTime && c.TodayDateTime<=toDateTime).AsNoTracking().ToList();
            return treatmentList;
        }
        public int SaveSendMedicine(List<SendMedicine> sendMedicines)
        {
            CMAContext db = new CMAContext();
            foreach (SendMedicine sendMedicine in sendMedicines)
            {
                db.SendMedicines.Add(sendMedicine);
            }
            int rowAffected = db.SaveChanges();
            return rowAffected;
        }
    }
}