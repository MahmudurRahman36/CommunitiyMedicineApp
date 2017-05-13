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
using System.Web.Security;
using System.Web.UI;
using CommunitiyMedicineApp.BLL;
using CommunitiyMedicineApp.Models;
using CommunitiyMedicineApp.Models.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

//using iTextSharp.text;

namespace CommunitiyMedicineApp.Controllers
{
    public class CenterOfficeController : Controller
    {
        //
        // GET: /CenterOffice/
        CenterManager centerManager = new CenterManager();
        HeadManager headManager = new HeadManager();

        public ActionResult Login()
        {
            Session["centerLogin"]=new Center();
            Session["CenterId"] = null;
            if (User.Identity.IsAuthenticated && Session["centerLogin"] != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(Center aCenter)
        {
            if (aCenter.Code==null||aCenter.Password==null)
            {
                return View(aCenter);
            }
            if (centerManager.DoesCodeExist(aCenter.Code))
            {
                aCenter = centerManager.GetCenterByLogIn(aCenter.Code, aCenter.Password);
                if (aCenter != null)
                {
                    FormsAuthentication.SetAuthCookie(aCenter.Name, false);
                    Session["centerLogin"] = aCenter;
                    Session["CenterId"] = aCenter.Id;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Password is incorrect!!!";
                }
            }
            else
            {
                ViewBag.Message = "Invalid Center Code!!!";
            }

            return View();
        }

        public ActionResult SaveDoctor()
        {

            if (User.Identity.IsAuthenticated && Session["centerLogin"] != null)
            {
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Login");
            }
            if (Session["CenterId"] == null)
            {
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Login");
            }
            var centerList = centerManager.GetAllCenters();
            ViewBag.centerList = new SelectList(centerList, "Id", "Name");
            ViewBag.CenterInfo = Session["CenterId"];
            return View();
        }

        [HttpPost]
        public ActionResult SaveDoctor(Doctor aDoctor)
        {
            if (ModelState.IsValid)
            {
                int rowAffected = centerManager.SaveDoctor(aDoctor);
                if (rowAffected > 0)
                {
                    ViewBag.Message = "Doctor information saved successfully.";
                }
                else
                {
                    ViewBag.Message = "Sorry!!! Your account cannot be created!";
                }
            }         
            var centerList = centerManager.GetAllCenters();
            ViewBag.centerList = new SelectList(centerList, "Id", "Name");
            ViewBag.CenterInfo = Session["CenterId"];
            return View();

        }

        public ActionResult MedicineStockReport()
        {
            if (User.Identity.IsAuthenticated && Session["centerLogin"] != null)
            {
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Login");
            }
            if (Session["CenterId"] == null)
            {
                ViewBag.Message = "Please Login First";
                return RedirectToAction("Login");
            }
            int centerId = (int) Session["CenterId"];
            List<CenterMedicineQuantity> centerMedicinelList = centerManager.GetCenterMedicineQuantity(centerId);
            ViewBag.MedicineList = centerMedicinelList;
            ViewBag.CenterInfo = Session["CenterId"];
            return View();
        }

        public ActionResult Treatment()
        {
            if (User.Identity.IsAuthenticated && Session["centerLogin"] != null)
            {
                return RedirectToAction("Login");
            }
            if (Session["CenterId"] == null)
            {
                return RedirectToAction("Login");
            }

            Session["TreatmentList"] = new List<Treatment>();

            var doctorList = centerManager.GetDoctorList();
            ViewBag.DoctorList = new SelectList(doctorList, "Id", "Name");

            var medicineList = headManager.GetMedicineList();
            ViewBag.MedicineList = new SelectList(medicineList, "Id", "GenericName");

            var diseaseList = headManager.GetDiseaseList();
            ViewBag.DiseaseList = new SelectList(diseaseList, "Id", "Name");

            var doseList = centerManager.GetDoseList();
            ViewBag.DoseList = new SelectList(doseList, "Id", "Name");
            ViewBag.CenterId = 5;
            ViewBag.CenterId = Session["CenterId"];
            PatientInfo patientInfo=new PatientInfo();
            ViewBag.personalInfo = patientInfo;
            return View();
        }
        [HttpPost]
        [CenterOfficeController.MultipleButtonAttribute(Name = "action", Argument = "Treatment")]
        public ActionResult Treatment(Treatment treatment)
        {
            List<Treatment> treatments = Session["TreatmentList"] as List<Treatment>;
            if (ModelState.IsValid)
            {
                treatments.Add(treatment);
                Session["TreatmentList"] = treatments;
                Session["TreatmentListForPdf"] = treatments;
                Session["PatientNIDNo"] = treatment.VoterIdNo;
            }

            var doctorList = centerManager.GetDoctorList();
            ViewBag.DoctorList = new SelectList(doctorList, "Id", "Name");

            var medicineList = headManager.GetMedicineList();
            ViewBag.MedicineList = new SelectList(medicineList, "Id", "GenericName");

            var diseaseList = headManager.GetDiseaseList();
            ViewBag.DiseaseList = new SelectList(diseaseList, "Id", "Name");

            var doseList = centerManager.GetDoseList();
            ViewBag.DoseList = new SelectList(doseList, "Id", "Name");

            ViewBag.TreatmentList = centerManager.GiveNameToTreatment(treatments);
            Session["TreatmentListPdf"] = centerManager.GiveNameToTreatment(treatments);
            ViewBag.Message = "Treatment Information Successfully Saved";
            PatientInfo patientInfo=new PatientInfo(){HdAddress = treatment.Address,HdName = treatment.Name,NIDno = treatment.VoterIdNo};
            ViewBag.personalInfo = patientInfo;
            ViewBag.CenterId = 5;
            ViewBag.CenterId = Session["CenterId"];
            return View(treatment);
        }

        [HttpPost]
        [CenterOfficeController.MultipleButtonAttribute(Name = "action", Argument = "GotoShowAllInformation")]
        public ActionResult GotoShowAllInformation(PatientInfo patientInfo)
        {
            return RedirectToAction("HistoryOfPatient", new { nid = patientInfo.NIDno,name=patientInfo.HdName,address=patientInfo.HdAddress });
        }

        [HttpPost]
        [CenterOfficeController.MultipleButtonAttribute(Name = "action", Argument = "SaveTreatment")]
        public ActionResult SaveTreatment(Treatment treatment)
        {
            List<Treatment> treatments = Session["TreatmentList"] as List<Treatment>;           
            if (centerManager.SaveTreatment(treatments) > 0)
            {
                Session["TreatmentList"] = new List<Treatment>();
                return RedirectToAction("GetTreatmentResult", "CenterOffice", new { treatmentss = treatments });
            }

            var doctorList = centerManager.GetDoctorList();
            ViewBag.DoctorList = new SelectList(doctorList, "Id", "Name");

            var medicineList = headManager.GetMedicineList();
            ViewBag.MedicineList = new SelectList(medicineList, "Id", "GenericName");

            var diseaseList = headManager.GetDiseaseList();
            ViewBag.DiseaseList = new SelectList(diseaseList, "Id", "Name");

            var doseList = centerManager.GetDoseList();
            ViewBag.DoseList = new SelectList(doseList, "Id", "Name");

            ViewBag.CenterId = 5;
            ViewBag.CenterId = Session["CenterId"];
            ViewBag.Message = "Sorry Data failed to Save";
            return View("Treatment");
        }
        public int GetNoOfTreatment(string voterId)
        {
            int no = centerManager.GetNoOfTreatmentById(voterId);
            return no;
        }
        public ActionResult GetTreatmentResult(List<Treatment> treatmentss)
        {
            ViewBag.CenterInfo = Session["CenterId"];
            ViewBag.VoterIdNo = Session["PatientNIDNo"];
            List<Treatment> treatments = Session["TreatmentListForPdf"] as List<Treatment>;
            ViewBag.TreatmentList = centerManager.GiveNameToTreatment(treatments);
            return View();
        }
        public ActionResult HistoryOfPatient(string nid,string name,string address)
        {
            PatientInfo patient=new PatientInfo(){HdAddress = address, HdName = name, NIDno = nid};
            ViewBag.PatientInfo = patient;
            ViewBag.PatientHistorys = centerManager.GetTreatmentList(nid);
            return View();
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "CenterOffice");
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

        public ActionResult Index()
        {
            return View();
        }
       
    }
}