using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShowCase1.Models.Classes;
namespace ProductShowCase1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var products = c.Products.Where(x => x.Status == true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.vle1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductRemove(int id)
        {
            var value = c.Products.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductBring(int id)
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.vle1 = value1;
            var productValue = c.Products.Find(id);
            return View("ProductBring", productValue);
        }
        public ActionResult ProductUpdate(Product p)
        {
            var prot = c.Products.Find(p.ProductID);
            prot.PurchasePrice = p.PurchasePrice;
            prot.Status = p.Status;
            prot.CategoryID = p.CategoryID;
            prot.Brand = p.Brand;
            prot.SalePrice = p.SalePrice;
            prot.Stock = p.Stock;
            prot.ProductName = p.ProductName;
            prot.ProductFeature = p.ProductFeature;
            prot.ProductImage = p.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}