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

        //     Controlling products categories: add, edit, delete.

        //     For adding a new product category
        [HttpGet]
        public ActionResult addProductCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addProductCategory(Product_Category newProductCategory)
        {
            db.productCategories.Add(newProductCategory);
            db.SaveChanges();
            return View();
        }

        //     For editing an exiting product category:
        [HttpGet]
        public ActionResult editProductCategory(string oldCategoryName)
        {
            //  Get the specific category by its name, provided by the admin:
            var oldProductCategory = db.productCategories.Single(x => x.categoryName == oldCategoryName);
            TempData["oldCategoryName"] = oldCategoryName;
            return View(oldProductCategory);
        }
        [HttpPost]
        public ActionResult editProductCategory(Product_Category newProductCategory)
        {
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
            return View();
        }
        [HttpPost]
        public ActionResult addProduct(Product newProduct)
        {
            db.products.Add(newProduct);
            db.SaveChanges();
            return View();
        }

        //     For editing an exiting product:
        [HttpGet]
        public ActionResult editProduct(int oldProductId)
        {
            //  Get the specific product by its ID
            var oldProduct = db.products.Single(x => x.productId == oldProductId);
            TempData["oldProductId"] = oldProductId;
            return View(oldProduct);
        }
        [HttpPost]
        public ActionResult editProduct(Product newProduct)
        {
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
            var product = db.products.Single(x => x.productId == productId);
            db.products.Remove(product);
            db.SaveChanges();
            return View();
        }

        //     Controlling complaints.

        //     For reviewing customers complaints:
        [HttpGet]
        public ActionResult viewComplaints()
        {
            var complaints = db.customerCompaints;
            return View(complaints);
        }
    }
}