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
        //     Note: no paying method is added yet.

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
            if (Session["customerId"] != null)
            {
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }
        [HttpPost]
        public ActionResult customerLogin(Customer newCustomer)
        {
            if (Session["customerId"] != null)
            {
                return RedirectToAction("Index", "Customer");
            }

            var checkCustomer = db.customers.SingleOrDefault(x => x.customerEmail == newCustomer.customerEmail && x.customerPassword == newCustomer.customerPassword);
            if (checkCustomer == null)
            {
                ViewBag.LogInError = "Email Or Password is encorrect!";
                return RedirectToAction("customerLogin");
            }

            Session["customerId"] = checkCustomer.customerId;
            return RedirectToAction("Index");
        }

        //     For Controlling the cart:

        //     The first time the customer adds a new item to the cart:
        //          it will create a new cart for him, put the item in it.
        //     Secound time he adds an item it will be added to exiting cart.
        //
        //     The cart will be saved as long as the customer didn't confirm the buying, or he didn't delete it.
        //     So even if the Internet crashes, the cart will be saved and shown the next time he logins.

        //     Customer's cart:
        public ActionResult showCart()
        {
            if (Session["customerId"] == null)
            {
                return RedirectToAction("customerLogin", "Customer");
            }

            var Cart = db.carts.Single(x => x.customerId == (int)Session["customerId"] && !x.isPurchased);
            return View(Cart);
        }

        //     Adding items to cart:
        [HttpGet]
        public ActionResult addToCart(Product product)
        {
            if (Session["customerId"] == null)
            {
                return RedirectToAction("customerLogin", "Customer");
            }

            return View(product);
        }
        [HttpPost]
        public ActionResult addToCart(Cart_Detail cartDetails)
        {
            if (Session["customerId"] == null)
            {
                return RedirectToAction("customerLogin", "Customer");
            }

            var Cart = db.carts.Single(x => x.customerId == (int)Session["customerId"] && !x.isPurchased);
            cartDetails.cartId = Cart.cartId;
            cartDetails.dateAdded = DateTime.Now;
            db.cartDetails.Add(cartDetails);
            db.SaveChanges();
            return View();
        }
    }
}