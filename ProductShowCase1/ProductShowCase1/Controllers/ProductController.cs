using System;
using System.Collections.Generic;
using System.IO;
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

        [Authorize]
        public ActionResult Index()
        {
            var products = c.Products.Where(x => x.Status == true).ToList();
            return View(products);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public ActionResult ProductAdd(Product p)
        {
            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.ProductImage = "/Image/" + dosyaadi + uzanti;
            }
            if (Request.Files.Count > 0 && Request.Files[1] != null && Request.Files[1].ContentLength > 0)
            {
                string dosyaadi2 = Path.GetFileName(Request.Files[1].FileName);
                string uzanti = Path.GetExtension(Request.Files[1].FileName);
                string yol = "~/Image/" + dosyaadi2 + uzanti;
                Request.Files[1].SaveAs(Server.MapPath(yol));
                p.ProductImage2 = "/Image/" + dosyaadi2 + uzanti;
            }
            if (Request.Files.Count > 0 && Request.Files[2] != null && Request.Files[2].ContentLength > 0)
            {
                string dosyaadi3 = Path.GetFileName(Request.Files[2].FileName);
                string uzanti = Path.GetExtension(Request.Files[2].FileName);
                string yol = "~/Image/" + dosyaadi3 + uzanti;
                Request.Files[2].SaveAs(Server.MapPath(yol));
                p.ProductImage3 = "/Image/" + dosyaadi3 + uzanti;
            }
            if (Request.Files.Count > 0 && Request.Files[3] != null && Request.Files[3].ContentLength > 0)
            {
                string dosyaadi4 = Path.GetFileName(Request.Files[3].FileName);
                string uzanti = Path.GetExtension(Request.Files[3].FileName);
                string yol = "~/Image/" + dosyaadi4 + uzanti;
                Request.Files[3].SaveAs(Server.MapPath(yol));
                p.ProductImage4 = "/Image/" + dosyaadi4 + uzanti;
            }
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult ProductRemove(int id)
        {
            var value = c.Products.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
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

        [Authorize]
        public ActionResult ProductUpdate(Product p, 
            HttpPostedFileBase ProductImage, HttpPostedFileBase ProductImage2, HttpPostedFileBase ProductImage3, HttpPostedFileBase ProductImage4)
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

            if (ModelState.IsValid)
            {
                if (ProductImage != null && ProductImage.ContentLength > 0)
                {
                    string dosyaadi = Path.GetFileName(ProductImage.FileName);
                    string uzanti = Path.GetExtension(ProductImage.FileName);
                    string yol = "~/Image/" + dosyaadi + uzanti;
                    ProductImage.SaveAs(Server.MapPath(yol));
                    prot.ProductImage = "/Image/" + dosyaadi + uzanti;
                }

                if (ProductImage2 != null && ProductImage2.ContentLength > 0)
                {
                    string dosyaadi2 = Path.GetFileName(ProductImage2.FileName);
                    string uzanti = Path.GetExtension(ProductImage2.FileName);
                    string yol = "~/Image/" + dosyaadi2 + uzanti;
                    ProductImage2.SaveAs(Server.MapPath(yol));
                    prot.ProductImage2 = "/Image/" + dosyaadi2 + uzanti;
                }

                if (ProductImage3 != null && ProductImage3.ContentLength > 0)
                {
                    string dosyaadi3 = Path.GetFileName(ProductImage3.FileName);
                    string uzanti = Path.GetExtension(ProductImage3.FileName);
                    string yol = "~/Image/" + dosyaadi3 + uzanti;
                    ProductImage3.SaveAs(Server.MapPath(yol));
                    prot.ProductImage3 = "/Image/" + dosyaadi3 + uzanti;
                }

                if (ProductImage4 != null && ProductImage4.ContentLength > 0)
                {
                    string dosyaadi4 = Path.GetFileName(ProductImage4.FileName);
                    string uzanti = Path.GetExtension(ProductImage4.FileName);
                    string yol = "~/Image/" + dosyaadi4 + uzanti;
                    ProductImage4.SaveAs(Server.MapPath(yol));
                    prot.ProductImage4 = "/Image/" + dosyaadi4 + uzanti;
                }

            }


            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}