using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Copper_Tools_Project.Models;
using Online_Copper_Tools_Project.Tools;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Online_Copper_Tools_Project.Controllers
{
    public class CustomerController : Controller
    {
        OCT_Model db = new OCT_Model();
        public ActionResult Index()
        {
            return View();
        }

        //     For the customer's account:

        //     For creating a new account:
        [HttpGet]
        public ActionResult customerSignup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult customerSignup(Customer newCustomer)
        {
            db.customers.Add(newCustomer);
            db.SaveChanges();
            return View();
        }

        //     For loggin in:
        [HttpGet]
        public ActionResult customerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult customerLogin(Customer newCustomer)
        {
            var checkCustomer = db.customers.SingleOrDefault(x => x.customerEmail == newCustomer.customerEmail && x.customerPassword == newCustomer.customerPassword);
            if (checkCustomer == null)
            {
                ViewBag.LogInError = "Email Or Password is encorrect!";
                return RedirectToAction("customerLogin");
            }
            return RedirectToAction("Index");
        }
    }
}