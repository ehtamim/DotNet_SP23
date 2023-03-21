using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class NgoController : Controller
    {
        // GET: Ngo
        [HttpGet]
        public ActionResult NgoDashboard()
        {
            ZHContext db = new ZHContext();
            /*var data = (from fr in db.FoodRequests
                        join r in db.Resturants
                        on fr.ResturantId equals r.Id
                        select new
                        {
                            ReqId = fr.Id,
                            ResturantName = r.Name,
                            ResturantContact = r.PhoneNumber,
                            ResturantLocation = r.Location,
                            RequestDescription = fr.Description,
                            RequestPreserveDate = fr.PreserveDate,
                            RequestDate = fr.Request_Date
                        });*/
            //Session["emp"] = db.Employees.ToList();
            /*var res = (from u in db.FoodRequests
            where u.Status.Equals(2)
                       select u).SingleOrDefault();*/
            var foodreq=db.FoodRequests.ToList();
            return View(foodreq);
        }
        [HttpPost]
        public ActionResult NgoDashboard(AcceptedRequest acceptedRequest)
        {
            ZHContext db = new ZHContext();
            db.AcceptedRequests.Add(acceptedRequest);
            db.SaveChanges();
            FoodRequest food= db.FoodRequests.FirstOrDefault();
            food.Status= 2;
            food.Action_Date= DateTime.Now.ToString("dd-MM-yyyy");
            db.SaveChanges();
            return RedirectToAction("NgoDashboard", "Ngo");
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            ZHContext db = new ZHContext();
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("AllEmployee", "Ngo");
            //return View();
        }
        public ActionResult AllEmployee() 
        {
            ZHContext db = new ZHContext();
            var employees = db.Employees.ToList();
            return View(employees);
        }
    }
}