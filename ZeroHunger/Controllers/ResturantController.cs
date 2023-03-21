using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class ResturantController : Controller
    {
        // GET: Resturant
        public ActionResult ResturantDashboard()
        {
            /*ZHContext db = new ZHContext();
            int resid = Convert.ToInt32(Session["id"]);
            var res = (from u in db.FoodRequests
            where u.ResturantId.Equals(resid)
                       select u).SingleOrDefault();
            var foodrequest = db.FoodRequests.ToList();
            return View(foodrequest);*/
            ZHContext db = new ZHContext();
            var foodrequest = db.FoodRequests.ToList();
            return View(foodrequest);
        }
        [HttpGet]
        public ActionResult FoodRequest() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult FoodRequest(FoodRequest foodRequest) 
        {
            ZHContext db = new ZHContext();
            foodRequest.Request_Date = DateTime.Now.ToString("dd-MM-yyyy");
            foodRequest.Status = 1;
            foodRequest.Action_Date = "00-00-0000";
            foodRequest.Delivery_Date = "00-00-0000";
            db.FoodRequests.Add(foodRequest);
            db.SaveChanges();
            return RedirectToAction("ResturantDashboard", "Resturant");
        }
    }
}