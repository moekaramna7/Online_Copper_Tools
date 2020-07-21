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
    public class AdminController : Controller
    {
        OCT_Model db = new OCT_Model();
        public ActionResult Index()
        {
            return View();
        }

        //     For the admins accounts // admins accounts will be manually added to the database

        //     For loggin in an admin account:
        [HttpGet]
        public ActionResult adminLogin()
        {
            if (Session["adminId"] != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        [HttpPost]
        public ActionResult adminLogin(Admin newAdmin)
        {
            if (Session["adminId"] != null)
            {
                return RedirectToAction("Index", "Admin");
            }

            var checkAdmin = db.admins.SingleOrDefault(x => x.adminEmail == newAdmin.adminEmail && x.adminPassword == newAdmin.adminPassword);
            if (checkAdmin == null)
            {
                ViewBag.LogInError = "Email Or Password is encorrect!";
                return RedirectToAction("adminLogin");
            }

            Session["adminId"] = checkAdmin.adminId;
            return RedirectToAction("Index");
        }

        //     Controlling products categories: add, edit, delete.

        //     For adding a new product category
        [HttpGet]
        public ActionResult addProductCategory()
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }

            return View();
        }
        [HttpPost]
        public ActionResult addProductCategory(Product_Category newProductCategory)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }

            db.productCategories.Add(newProductCategory);
            db.SaveChanges();
            return View();
        }

        //     For editing an exiting product category:
        [HttpGet]
        public ActionResult editProductCategory(string oldCategoryName)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }

            //  Get the specific category by its name, provided by the admin:
            var oldProductCategory = db.productCategories.Single(x => x.categoryName == oldCategoryName);
            TempData["oldCategoryName"] = oldCategoryName;
            return View(oldProductCategory);
        }
        [HttpPost]
        public ActionResult editProductCategory(Product_Category newProductCategory)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }

            string oldCategoryName = Convert.ToString(TempData["oldCategoryName"]);
            var oldProductCategory = db.productCategories.Single(x => x.categoryName == oldCategoryName);

            oldProductCategory.categoryName = newProductCategory.categoryName;
            db.productCategories.AddOrUpdate(oldProductCategory);
            db.SaveChanges();
            return View();
        }

        //     For deleting an exiting product category:
        public ActionResult deleteProductCategory(string categoryName)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }

            var productCategory = db.productCategories.Single(x => x.categoryName == categoryName);
            db.productCategories.Remove(productCategory);
            db.SaveChanges();
            return View();
        }

        //     Controlling products: add, edit, delete.

        //     For adding a new product:
        [HttpGet]
        public ActionResult addProduct()
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }

            return View();
        }
        [HttpPost]
        public ActionResult addProduct(Product newProduct)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }

            db.products.Add(newProduct);
            db.SaveChanges();
            return View();
        }

        //     For editing an exiting product:
        [HttpGet]
        public ActionResult editProduct(int oldProductId)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }

            //  Get the specific product by its ID
            var oldProduct = db.products.Single(x => x.productId == oldProductId);
            TempData["oldProductId"] = oldProductId;
            return View(oldProduct);
        }
        [HttpPost]
        public ActionResult editProduct(Product newProduct)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }

            int oldProductId = (int)TempData["oldProductId"];
            var oldProduct = db.products.Single(x => x.productId == oldProductId);

            oldProduct.productName = newProduct.productName;
            oldProduct.productCategory = newProduct.productCategory;
            if (newProduct.productSize != null)
                oldProduct.productSize = newProduct.productSize;
            oldProduct.productPrice = newProduct.productPrice;
            oldProduct.productDiscount = newProduct.productDiscount;

            db.products.AddOrUpdate(oldProduct);
            db.SaveChanges();
            return View();
        }

        //     For deleting an exiting product:
        public ActionResult deleteProduct(int productId)
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }

            var product = db.products.Single(x => x.productId == productId);
            db.products.Remove(product);
            db.SaveChanges();
            return View();
        }

        //     Controlling complaints.

        //     For reviewing customers complaints:
        //     Note: reply message for the complaints will be sent to the customer's email.
        [HttpGet]
        public ActionResult viewComplaints()
        {
            if (Session["adminId"] == null)
            {
                return RedirectToAction("adminLogin", "Admin");
            }
            var complaints = db.customerCompaints.Where(x => !x.isReplied);
            return View(complaints);
        }
    }
}