using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HPAF.Models;


namespace HPAF.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["UserName"] != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login loginModel)
        {
            if (System.Web.HttpContext.Current.Session["UserName"] != null)
                RedirectToAction("Index", "Home");
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(loginModel.UserName) || string.IsNullOrWhiteSpace(loginModel.Password))
            {
                return View();
            }
            DBData dbd = new DBData();
            DataTable userDetails = dbd.UserDetails(loginModel.UserName,loginModel.Password);
            if (userDetails != null)
            {
                if (userDetails.Rows.Count > 0)
                {
                    var istdate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                                        TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

                    foreach (DataRow item in userDetails.Rows)
                    {
                      //  SaltedHash sh = new SaltedHash();
                        if (loginModel.Password == item["Password"].ToString())
                        {
                            System.Web.HttpContext.Current.Session["UserName"] = item["UserName"];
                            System.Web.HttpContext.Current.Session["UserRoleId"] = item["RoleID"];
                            System.Web.HttpContext.Current.Session["UserRole"] = item["RoleName"];
                            System.Web.HttpContext.Current.Session["UserID"] = item["UserID"];
                            System.Web.HttpContext.Current.Session["UserRegionName"] = item["Region"];

                            if (Session["UserId"] != null)
                              
                                return RedirectToAction("Index", "Home");
                        }
                    }
                    TempData["Error"] = "Invalid Username or Password";
                    return View();
                }
                else
                {
                    TempData["Error"] = "Invalid Username or Password";
                    return View();
                }
            }
            else
            {
                TempData["Error"] = "No Such User existis. Please use New Registration to Register";
                return View();
            }
        }
        public ActionResult Directlogin(Login loginModel)
        {
            if (System.Web.HttpContext.Current.Session["UserName"] != null)
                RedirectToAction("Index", "Home");
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(loginModel.UserName) || string.IsNullOrWhiteSpace(loginModel.Password))
            {
                return View();
            }
            DBData dbd = new DBData();
            DataTable userDetails = dbd.UserDetails(loginModel.UserName,loginModel.Password);
            if (userDetails != null)
            {
                if (userDetails.Rows.Count > 0)
                {
                    var istdate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                                        TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

                    foreach (DataRow item in userDetails.Rows)
                    {
                        //SaltedHash sh = new SaltedHash();
                        if (loginModel.Password== item["Password"].ToString())
                        {
                            System.Web.HttpContext.Current.Session["UserName"] = item["UserName"];
                            System.Web.HttpContext.Current.Session["UserRoleId"] = item["RoleID"];
                            System.Web.HttpContext.Current.Session["UserRole"] = item["RoleName"];
                            System.Web.HttpContext.Current.Session["UserID"] = item["UserID"];
                            System.Web.HttpContext.Current.Session["UserRegionName"] = item["Region"];
                            if (Session["UserId"] != null)
                                 return RedirectToAction("Index", "Home");

                            //else
                            //    return RedirectToAction("Index", "DocumentUpload");
                        }
                    }
                    TempData["Error"] = "Invalid Username or Password";
                    return View();
                }
                else
                {
                    TempData["Error"] = "Invalid Username or Password";
                    return View();
                }
            }
            else
            {
                TempData["Error"] = "No Such User existis. Please use New Registration to Register";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            DBData dbd = new DBData();
            var istdate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                                       TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            if (Session["UserId"] != null)
                dbd.LogUserActivity(Convert.ToInt32(Session["UserId"]), "Logout", istdate);

            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session.Abandon();
            System.Web.HttpContext.Current.Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}