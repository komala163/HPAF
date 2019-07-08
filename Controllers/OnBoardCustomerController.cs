using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using HPAF.Controllers;

namespace iDMS.Controllers
{
    public class OnBoardCustomerController : Controller
    {
        // GET: OnBoardCustomer
        public ActionResult CustomerDetails()
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


        public int InsertOnBoardCustomerDetails(string jsoncustomer, string jsonguaranter, string jsonvehicle, string jsonscheme)
        {
            DBData db = new DBData();
            int k = db.InsertOnBoardCustomerDetails_db(jsoncustomer, jsonguaranter, jsonvehicle, jsonscheme);
            return k;
        }



        //DBdata
       
    }
}



