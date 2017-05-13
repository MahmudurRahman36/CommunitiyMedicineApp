using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CommunitiyMedicineApp.BLL;
using CommunitiyMedicineApp.Models;
using CommunitiyMedicineApp.Models.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
//using Rotativa;

namespace CommunitiyMedicineApp.Controllers
{
    public class HeadOfficeController : Controller
    {

        HeadManager headManager = new HeadManager();
        public ActionResult MedicineEntry()
        {
            List<Medicine> medicineList = headManager.GetMedicineList();
            ViewBag.MedicineList = medicineList;
            return View();
        }

        [HttpPost]
        public ActionResult MedicineEntry(Medicine medicine)
        {
            List<Medicine> medicineList = headManager.GetMedicineList();
            ViewBag.MedicineList = medicineList;

            if (!ModelState.IsValid)
            {
                return View(medicine);
            }
            string saveConfirmMsg;
            if (headManager.IsMedicineExist(medicine.GenericName, medicine.MgMl))
            {
                saveConfirmMsg = "Data already exist";
            }
            else if (headManager.SetMedicine(medicine))
            {
                saveConfirmMsg = "Data Saved";
            }
            else
            {
                saveConfirmMsg = "Data not Saved";
            }
            
            ViewBag.SaveConfirmMsg = saveConfirmMsg;
            return View();
        }

        public ActionResult DiseaseEntry()
        {
            List<Disease> diseaseList = headManager.GetDiseaseList();
            ViewBag.DiseaseList = diseaseList;
            return View();
        }

        [HttpPost]
        public ActionResult DiseaseEntry(Disease disease)
        {
            List<Disease> diseaseList = headManager.GetDiseaseList();
            ViewBag.DiseaseList = diseaseList;

            if (!ModelState.IsValid)
            {
                return View(disease);
            }

            if (headManager.IsDiseaseExist(disease.Name))
            {
                ViewBag.SaveConfirmMsg = "Disease Name Already Exist";
            }
            else if (headManager.SetDisease(disease))
            {
                ViewBag.SaveConfirmMsg = "Data saved";
            }
            else
            {
                ViewBag.SaveConfirmMsg = "Data saved failed";
            }
            
            return View();
        }

        public ActionResult CenterEntry()
        {
            List<District> districtList = headManager.GetDistrictList();
            List<Thana> thanaList = headManager.GetThanaList();
            ViewBag.DistrictList = districtList;
            ViewBag.ThanaList = thanaList;
            return View();
        }
        [HttpPost]
        public ActionResult CenterEntry(Center aCenter)
        {
            List<District> districtList = headManager.GetDistrictList();
            List<Thana> thanaList = headManager.GetThanaList();
            ViewBag.DistrictList = districtList;
            ViewBag.ThanaList = thanaList;

            if (!ModelState.IsValid)
            {
                return View(aCenter);
            }
           
            bool doesCenterExits = headManager.IsCenterExist(aCenter);
            if (doesCenterExits)
            {
                ViewBag.SaveSuccessMsg = "Center Already Exsits";
            }
            else
            {
                List<string> codePassword = headManager.GeneratedCodeAndPassword(aCenter.DistrictId, aCenter.ThanaId);
                aCenter.Code = codePassword[0];
                aCenter.Password = codePassword[1];
                if (headManager.SetCenter(aCenter))
                {
                    ViewBag.SaveSuccessMsg = "Successful. Center information saved.";
                    CenterPdf centerPdf = new CenterPdf()
                    {
                        CenterName = aCenter.Name,
                        DistrictName = headManager.GetDistrictNameById(aCenter.DistrictId),
                        ThanaName = headManager.GetThanaNameById(aCenter.ThanaId),
                        Code = aCenter.Code,
                        Password = aCenter.Password
                    };
                    Session["CenterPdf"] = centerPdf;
                    Session["CenterOtherPdf"] = aCenter;
                    return RedirectToAction("CenterInformation", centerPdf);
                }
                else
                {
                    ViewBag.SaveSuccessMsg = "Failed.";
                }
            }
            return View();
        }

        public JsonResult GetThanaList(int districtId)
        {
            var thana = headManager.GetThanaList();
            var studentList = thana.Where(a => a.DistrictId == districtId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCenterList(int districtId, int thanaId)
        {

            var center = headManager.GetCenterList();
            var centerList = center.Where(a => a.DistrictId == districtId && a.ThanaId == thanaId).ToList();

            return Json(centerList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DiseaseWiseReport()
        {
            var diseaseList = headManager.GetDiseaseList();
            ViewBag.DiseaseList = new SelectList(diseaseList, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult DiseaseWiseReport(DiseaseDate diseaseDate)
        {
            var diseaseList = headManager.GetDiseaseList();
            ViewBag.DiseaseList = new SelectList(diseaseList, "Id", "Name");

            if (!ModelState.IsValid)
            {
                return View(diseaseDate);
            }
            ViewBag.DiseaseWiseReport = headManager.GetDiseaseWiseReports(diseaseDate);
            
            return View();
        }

        public ActionResult SendMedicine()
        {
            Session["SendMedicine"] = new List<SendMedicine>();

            var districtList = headManager.GetDistrictList();
            ViewBag.DistrictList = new SelectList(districtList, "Id", "Name");

            var thanaList = headManager.GetThanaList();
            ViewBag.ThanaList = new SelectList(thanaList, "Id", "Name");

            var centerList = headManager.GetCenterList();
            ViewBag.CenterList = new SelectList(centerList, "Id", "Name");

            var medicineList = headManager.GetMedicineList();
            ViewBag.MedicineList = new SelectList(medicineList, "Id", "GenericName");

            return View();
        }
        [HttpPost]
        [HeadOfficeController.MultipleButtonAttribute(Name = "action", Argument = "SendMedicine")]
        public ActionResult SendMedicine(SendMedicine sendMedicine)
        {
            var districtList = headManager.GetDistrictList();
            ViewBag.DistrictList = new SelectList(districtList, "Id", "Name");

            var thanaList = headManager.GetThanaList();
            ViewBag.ThanaList = new SelectList(thanaList, "Id", "Name");

            var centerList = headManager.GetCenterList();
            ViewBag.CenterList = new SelectList(centerList, "Id", "Name");

            var medicineList = headManager.GetMedicineList();
            ViewBag.MedicineList = new SelectList(medicineList, "Id", "GenericName");

            List<SendMedicine> sendMedicines = (Session["SendMedicine"]) as List<SendMedicine>;
            ViewBag.SendMedicine = sendMedicines;

            if (!ModelState.IsValid)
            {
                return View(sendMedicine);
            }

            sendMedicines.Add(sendMedicine);
            Session["SendMedicine"] = sendMedicines;

            foreach (SendMedicine medicine in sendMedicines)
            {
                medicine.MedicineName = headManager.GetMedicineNamebyId(medicine.MedicineId).GenericName;
            }                              

            ViewBag.SendMedicine = sendMedicines;
            ViewBag.Message = "Medicine Added To the List";
            return View(sendMedicine);
        }
        [HttpPost]
        [HeadOfficeController.MultipleButtonAttribute(Name = "action", Argument = "SaveMedicine")]
        public ActionResult SaveMedicine(string Name)
        {
            var districtList = headManager.GetDistrictList();
            ViewBag.DistrictList = new SelectList(districtList, "Id", "Name");

            var thanaList = headManager.GetThanaList();
            ViewBag.ThanaList = new SelectList(thanaList, "Id", "Name");

            var centerList = headManager.GetCenterList();
            ViewBag.CenterList = new SelectList(centerList, "Id", "Name");

            var medicineList = headManager.GetMedicineList();
            ViewBag.MedicineList = new SelectList(medicineList, "Id", "GenericName");

            List<SendMedicine> sendMedicines = (Session["SendMedicine"]) as List<SendMedicine>;
            if (sendMedicines.Count!=0)
            {
                int rowAffected = headManager.SaveSendMedicine(sendMedicines);
                ViewBag.Message = "Medinice list is saved for sending ";
                Session["SendMedicine"] = new List<SendMedicine>();
            }
            else
            {
                ViewBag.Message = "Please add some Medinice first.";
                Session["SendMedicine"] = new List<SendMedicine>();
            }
            return View("SendMedicine");
        }
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class MultipleButtonAttribute : ActionNameSelectorAttribute
        {
            public string Name { get; set; }
            public string Argument { get; set; }

            public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
            {
                var isValidName = false;
                var keyValue = string.Format("{0}:{1}", Name, Argument);
                var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

                if (value != null)
                {
                    controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                    isValidName = true;
                }

                return isValidName;
            }
        }
        public ActionResult CenterInformation(CenterPdf newCenter)
        {
            if (newCenter == null)
            {
                newCenter = Session["CenterOtherPdf"] as CenterPdf;
            }
            Document document = new Document();

            MemoryStream stream = new MemoryStream();

            try
            {
                PdfWriter pdfWriter = PdfWriter.GetInstance(document, stream);
                pdfWriter.CloseStream = false;

                document.Open();
                document.Add(new Paragraph("Center Information"));
                document.Add(new Paragraph("Center Name: " + newCenter.CenterName));
                document.Add(new Paragraph("District : " + newCenter.DistrictName));
                document.Add(new Paragraph("Thana : " + newCenter.ThanaName));
                document.Add(new Paragraph("Code : " + newCenter.Code));
                document.Add(new Paragraph("Password : " + newCenter.Password));
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }

            document.Close();

            stream.Flush(); //Always catches me out
            stream.Position = 0; //Not sure if this is required

            return File(stream, "application/pdf", "CenterInformation.pdf");
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DiseasesDemographicReport()
        {
            var diseaseList = headManager.GetDiseaseList();
            ViewBag.DiseaseList = new SelectList(diseaseList, "Id", "Name");
            ArrayList headerData = new ArrayList { "District Name Name", "Hours", "CS" };
            ArrayList data1 = new ArrayList { "District Name", 0, 0 };
            ArrayList data = new ArrayList { headerData, data1 };
            string datastr = JsonConvert.SerializeObject(data, Formatting.None);
            ViewBag.Data = new HtmlString(datastr);
            return View();
        }

        [HttpPost]
        public ActionResult DiseasesDemographicReport(DiseaseDate diseaseDate)
        {
            if (!ModelState.IsValid)
            {
                return View(diseaseDate);
            }
            var DiseaseWiseReport = headManager.GetDiseaseWiseReports(diseaseDate);
            var diseaseList = headManager.GetDiseaseList();
            ViewBag.DiseaseList = new SelectList(diseaseList, "Id", "Name");
            ArrayList headerData = new ArrayList { "District Name", "No of Patient", "CS" };
            ArrayList data = new ArrayList();
            data.Add(headerData);
            foreach (var d in DiseaseWiseReport)
            {
                ArrayList data1 = new ArrayList { d.DistrictName, d.TotalPatients, d.TotalPatients };
                data.Add(data1);
            }
            string datastr = JsonConvert.SerializeObject(data, Formatting.None);
            ViewBag.Data = new HtmlString(datastr);
            return View();
        }

        [HttpGet]
        public ActionResult DiseaseBarChartReport()
        {
            var districtList = headManager.GetDistrictList();
            ViewBag.DistrictList = new SelectList(districtList, "Id", "Name");
            ArrayList headerData = new ArrayList { "Disease Name", "No of Patient" };
            ArrayList data1 = new ArrayList { "Disease", 0 };
            ArrayList data = new ArrayList { headerData, data1 };
            string datastr = JsonConvert.SerializeObject(data, Formatting.None);
            ViewBag.Data = new HtmlString(datastr);
            return View();
        }

        [HttpPost]
        public ActionResult DiseaseBarChartReport(DiseaseDate diseaseDate)
        {
            if (!ModelState.IsValid)
            {
                return View(diseaseDate);
            }
            var districtWiseReport = headManager.GetPatientOfDiseaseIndisease(diseaseDate.DiseaseId, diseaseDate.BeginDateTime, diseaseDate.EndDateTime);
            var districtList = headManager.GetDistrictList();
            ViewBag.DistrictList = new SelectList(districtList, "Id", "Name");
            ArrayList headerData = new ArrayList { "Disease Name", "No of Patient" };
            ArrayList data = new ArrayList();
            data.Add(headerData);
            foreach (var d in districtWiseReport)
            {
                ArrayList data1 = new ArrayList { d.DiseaseName, d.Patient };
                data.Add(data1);
            }
            string datastr = JsonConvert.SerializeObject(data, Formatting.None);
            ViewBag.Data = new HtmlString(datastr);
            return View();

        }
       
    }
}