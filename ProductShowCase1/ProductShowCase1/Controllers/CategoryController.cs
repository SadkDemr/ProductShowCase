using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShowCase1.Models.Classes;

namespace ProductShowCase1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var values = c.Categories.ToList();
            return View(values);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CategoryAdd(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult CategoryRemove(int ID)
        {
            var kate = c.Categories.Find(ID);
            c.Categories.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult CategoryBring(int ID)
        {
            var category = c.Categories.Find(ID);
            return View("CategoryBring", category);
        }

        [Authorize]
        public ActionResult CategoryUpdate(Category k)
        {
            var ktgr = c.Categories.Find(k.CategoryID);
            ktgr.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}