using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HPAF.Models;
using HPAF.Controllers;
using System.Data;

namespace HPAF.Controllers
{
    public class EMIPaymentController : Controller
    {
        // GET: EMIPayment

        DBData db = new DBData();
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["UserName"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        public JsonResult GetDataforEMIPayment(string EMIPaymentInput)
        {
            EMIPayment e = new EMIPayment();
            var EMIData = new List<EMIWorkList>();
            DataTable dt = new DataTable();
            dt = db.GetDataforEMIUpdate(EMIPaymentInput);
            if(dt!=null)
            {
                foreach(DataRow row in dt.Rows)
                {
                    e.CustomerName = row["CustomerName"] != DBNull.Value ? row["CustomerName"].ToString() : string.Empty;
                    e.VehicleNo = row["VehicleNo"] != DBNull.Value ? row["VehicleNo"].ToString() : string.Empty;
                    e.EMIAmount = row["EMIAmount"] != DBNull.Value ? row["EMIAmount"].ToString() : string.Empty;
                    e.TotalAmountInThisMonth = row["TotalAmountInthisEMI"] != DBNull.Value ? row["TotalAmountInthisEMI"].ToString() : string.Empty;
                    e.TotalEMIs = row["NoOfEMI"] != DBNull.Value ? row["NoOfEMI"].ToString() : string.Empty;
                    e.BalanceAmount = row["BalanceAmount"] != DBNull.Value ? row["BalanceAmount"].ToString() : string.Empty;
                    e.StoreLocation = row["StoreLocation"] != DBNull.Value ? row["StoreLocation"].ToString() : string.Empty;
                    e.TotalLoanAmount = row["TotalLoanAmount"] != DBNull.Value ? row["TotalLoanAmount"].ToString() : string.Empty;
                    e.DueDate = row["DueDate"] != DBNull.Value ? row["DueDate"].ToString() : string.Empty;
                    e.CustomerID = row["CustomerID"] != DBNull.Value ? row["CustomerID"].ToString() : string.Empty;
                    e.AgreementID= row["AgreementID"] != DBNull.Value ? row["AgreementID"].ToString() : string.Empty;
                    e.NoODaysDelayed = row["DelayedDays"] != DBNull.Value ? row["DelayedDays"].ToString() : string.Empty;
                }
            }
              EMIData = RetrieveEMIPaymentRecords(EMIPaymentInput);
              e.EMIWorkList = EMIData;
            return Json(e, JsonRequestBehavior.AllowGet);
        }

        private List<EMIWorkList> RetrieveEMIPaymentRecords(string EMIPaymentInput)
        {
            var EMIWorklists = new List<EMIWorkList>();

            DataTable dt = db.EMIPaymentTableRecord(EMIPaymentInput);
            if(dt!=null && dt.Rows.Count>0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EMIWorkList emi = new EMIWorkList();
                    emi.SNo= row["SNo"] != DBNull.Value ? row["SNo"].ToString() : string.Empty;
                    emi.EMIAmount = row["EMIAmount"] != DBNull.Value ? row["EMIAmount"].ToString() : string.Empty;
                    emi.DueDate = row["DueDate"] != DBNull.Value ? row["DueDate"].ToString() : string.Empty;
                    emi.EMIReceived = row["EMIReceived"] != DBNull.Value ? row["EMIReceived"].ToString() : string.Empty;
                    emi.LastReceivedDate = row["LastReceivedDate"] != DBNull.Value ? row["LastReceivedDate"].ToString() : string.Empty;
                    emi.NoofDaysDelayed = row["NoofDaysDelayed"] != DBNull.Value ? row["NoofDaysDelayed"].ToString() : string.Empty;
                    emi.Penalty = row["Penalty"] != DBNull.Value ? row["Penalty"].ToString() : string.Empty;
                    emi.Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : string.Empty;
                    EMIWorklists.Add(emi);
                }
               
             }
            return EMIWorklists;
        }

        public int UpdateEMIPayment(string jsonEMI)
        {
            DBData db = new DBData();
            int k = db.UpdateEMIPayment_db(jsonEMI);
            return k;
        }
    }
}