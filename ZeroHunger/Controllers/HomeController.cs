using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                ZHContext db = new ZHContext();
                var res = (from u in db.Resturants
                            where u.Email.Equals(login.Email) && u.Password.Equals(login.Password)
                            select u).SingleOrDefault();
                var emp = (from u in db.Employees
                           where u.Email.Equals(login.Email) && u.Password.Equals(login.Password)
                           select u).SingleOrDefault();
                var ngo = (from u in db.NGOS
                           where u.Email.Equals(login.Email) && u.Password.Equals(login.Password)
                           select u).SingleOrDefault();
                if (res != null)
                {
                    Session["user"] = res;
                    Session["id"]=res.Id;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("ResturantDashboard", "Resturant");
                }
                else if (emp !=null)
                {
                    Session["user"] = emp;
                    Session["id"] = emp.Id;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("EmployeeDashboard", "Employee");
                }
                else if (ngo != null)
                {
                    Session["user"] = ngo;
                    Session["id"] = ngo.Id;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null)
                    {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("NgoDashboard", "Ngo");
                }
                else
                {
                    Session["user"] = null;
                    ViewBag.Message = "Username Password invalid";
                }
            }
            //ViewBag.Message = "Username Password invalid";
            return View();
        }
        [HttpGet]
        public ActionResult Signup()
        {
            ViewBag.Message = "Signup page.";

            return View();
        }
        [HttpPost]
        public ActionResult Signup(Resturant resturant)
        {
            ZHContext db = new ZHContext();
            db.Resturants.Add(resturant);
            db.SaveChanges();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Logout()
        {
            Session["user"] = "";
            Session["id"] = "";
            return RedirectToAction("Index", "Home");
        }
    }
}