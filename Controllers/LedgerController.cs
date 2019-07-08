using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPAF.Controllers
{
    public class LedgerController : Controller
    {
        // GET: Ledger
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

         
     }
    
}