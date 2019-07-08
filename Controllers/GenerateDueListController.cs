using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using HPAF.Controllers;
using System.Text;

namespace HPAF.Controllers
{
    public class GenerateDueListController : Controller
    {
        // GET: GenerateDueList

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

        public String GetRecordsForGenerateDueList(string LocationCode)
        {
            DataTable Data = new DataTable();
            StringBuilder builder = new StringBuilder();
            string obj = string.Empty;
            int i = 1;
           Data = db.GetDataforGenerateDueList(LocationCode);
            if (Data != null)
            {
                foreach (DataRow row in Data.Rows)
                {
                    obj += "<tr>";
                    obj += "<td>" + i + "</td>";
                    obj += "<td>" + row["AgreementID"].ToString() + "</td>";
                    obj += "<td>" + row["VehicleNO"].ToString() + "</td>";
                    obj += "<td>" + row["VehicleName"].ToString() + "</td>";
                    obj += "<td>" + row["Model"].ToString() + "</td>";
                    obj += "<td>" + row["FirstName"].ToString() + "</td>";
                    obj += "<td>" + row["MobileNo"].ToString() + "</td>";
                    obj += "<td>" + row["EMIAmount"].ToString() + "</td>";
                    obj += "<td>" + row["DueDate"].ToString() + "</td>";
                    obj += "<td>" + row["PendingEMIs"].ToString() + "</td>";
                    obj += "<td>" + row["PreviousEMIPendingAmount"].ToString() + "</td>";
                    obj += "<td>" + row["TotalAmount"].ToString() + "</td>";
                    obj += "<td>" + row["LastPaid"].ToString() + "</td>";
                    obj += "</tr>";
                    builder.Append(obj);
                    obj = "";
                    i++;
                }
                
            }
             return builder.ToString();
        }

    }
}