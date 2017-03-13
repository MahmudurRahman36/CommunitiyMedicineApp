using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using CommunitiyMedicineApp.DAL;
using CommunitiyMedicineApp.Models;
using CommunitiyMedicineApp.Models.Entity;

namespace CommunitiyMedicineApp.BLL
{
    public class HeadManager
    {
        HeadGateway headGateway=new HeadGateway();

        public List<PatientInDistrict> GetDistrictWiseReports(DiseaseDate diseaseDate)
        {
            List<PatientInDistrict> patientInDistricts = new List<PatientInDistrict>();
            List<int> centerList = headGateway.GetCenterListByDistrictId(diseaseDate.DiseaseId);
            List<int> diseaseList = headGateway.GetDiseaseIdList();
            foreach (int d in diseaseList)
            {
                List<Treatment> treatments = new List<Treatment>();
                foreach (int i in centerList)
                {
                    List<Treatment> newTreatments = headGateway.GetTreatmentListByCenterId(i, d, diseaseDate.BeginDateTime, diseaseDate.EndDateTime);
                    treatments.AddRange(newTreatments);
                }
                PatientInDistrict patientInDistrict = new PatientInDistrict();
                patientInDistrict.DiseaseId = d;
                patientInDistrict.DiseaseName = GetDiseaseNamebyId(d).Name;
                patientInDistrict.Patient = treatments.GroupBy(x => x.VoterIdNo).Select(x => x.First()).Count();
                patientInDistricts.Add(patientInDistrict);
            }
            return patientInDistricts;
        }
        public List<Medicine> GetMedicineList()
        {
            List<Medicine> medicineList = headGateway.GetMedicineList();
            return medicineList;
        }

        public bool SetMedicine(Medicine medicine)
        {
            return headGateway.SetMedicine(medicine);
        }
        public bool IsMedicineExist(string name, double mgMl)
        {
            return headGateway.IsMedicineExist(name, mgMl);
        }

        public List<Disease> GetDiseaseList()
        {
            return headGateway.GetDiseaseList();
        }

        public bool IsDiseaseExist(string name)
        {
            return headGateway.IsDiseaseExist(name);
        }

        public bool SetDisease(Disease disease)
        {
            return headGateway.SetDisease(disease);
        }

        public List<Center> GetCenterList()
        {
            return headGateway.GetCenterList();
        }

        public string GetDistrictNameById(int districtId)
        {
            return headGateway.GetDistrictNameById(districtId);
        }

        public string GetThanaNameById(int thanaId)
        {
            return headGateway.GetThanaNameById(thanaId);
        }
        public Center GetCenterNamebyId(int centerId)
        {
            return headGateway.GetCenterNamebyId(centerId);
        }
        public Disease GetDiseaseNamebyId(int diseaseId)
        {
            return headGateway.GetDiseaseNamebyId(diseaseId);
        }
        public Medicine GetMedicineNamebyId(int medicineId)
        {
            return headGateway.GetMedicineNamebyId(medicineId);
        }
        public List<Thana> GetThanaList()
        {
            return headGateway.GetThanaList();
        }
        public List<District> GetDistrictList()
        {
            return headGateway.GetDistrictList();
        }
        public List<string> GeneratedCodeAndPassword(int districtId, int thanaId)
        {
            int centerCount = headGateway.CountCenterNumber(districtId,thanaId);
            string districtName = headGateway.GetDistrictNamebyId(districtId).Name;
            string str1 = districtName.Substring(0, 3);
            string thanaName = headGateway.GetThanaNamebyId(thanaId).Name;
            string str2 = thanaName.Substring(0, 3);
            string centerCode = string.Concat(str1, "-", str2, "-", centerCount);
            string centerPassword = Membership.GeneratePassword(5, 0);
            List<string> codeAndpassword = new List<string>();
            codeAndpassword.Add(centerCode);
            codeAndpassword.Add(centerPassword);
            return codeAndpassword;
        }

        public bool IsCenterExist(Center center)
        {
            return headGateway.IsCenterExist(center);
        }

        public bool SetCenter(Center aCenter)
        {
            return headGateway.SetCenter(aCenter);
        }

        public List<DiseaseWiseReport> GetDiseaseWiseReports(DiseaseDate diseaseDate)
        {
            List<District> districts=headGateway.GetDistrictList();
            List<DiseaseWiseReport> diseaseWiseReports=new List<DiseaseWiseReport>();
            foreach (District district in districts)
            {
                List<Treatment> treatments=new List<Treatment>();
                List<int> centerList = headGateway.GetCenterListByDistrictId(district.Id);
                foreach (int i in centerList)
                {
                    List<Treatment> newTreatments = headGateway.GetTreatmentListByCenterId(i, diseaseDate.DiseaseId,diseaseDate.BeginDateTime,diseaseDate.EndDateTime);
                    treatments.AddRange(newTreatments);
                }
                DiseaseWiseReport diseaseWiseReport=new DiseaseWiseReport();
                diseaseWiseReport.DistrictId = district.Id;
                diseaseWiseReport.DistrictName = district.Name;
                diseaseWiseReport.TotalPatients = treatments.GroupBy(x => x.VoterIdNo).Select(x => x.First()).Count();
                diseaseWiseReport.PercentageOfPopulation = ((double)diseaseWiseReport.TotalPatients*100/(double)district.Population);
                diseaseWiseReports.Add(diseaseWiseReport);
            }
            return diseaseWiseReports;
        }

        public List<PatientInDistrict> GetPatientOfDiseaseIndisease(int districtId,DateTime beginDate,DateTime endDate)
        {
            List<PatientInDistrict> patientInDistricts=new List<PatientInDistrict>();
            List<int> centerList = headGateway.GetCenterListByDistrictId(districtId);
            List<int> diseaseList = headGateway.GetDiseaseIdList();
            foreach (int d in diseaseList)
            {
                List<Treatment> treatments = new List<Treatment>();
                foreach (int i in centerList)
                {
                    List<Treatment> newTreatments = headGateway.GetTreatmentListByCenterId(i, d, beginDate, endDate);
                    treatments.AddRange(newTreatments);
                }
                PatientInDistrict patientInDistrict = new PatientInDistrict();
                patientInDistrict.DiseaseId = d;
                patientInDistrict.DiseaseName = GetDiseaseNamebyId(d).Name;
                patientInDistrict.Patient = treatments.GroupBy(x => x.VoterIdNo).Select(x => x.First()).Count();
                patientInDistricts.Add(patientInDistrict);
            }
            return patientInDistricts;
        }

        public int SaveSendMedicine(List<SendMedicine> sendMedicines)
        {
            return headGateway.SaveSendMedicine(sendMedicines);
        }
    }
}