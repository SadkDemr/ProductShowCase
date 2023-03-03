using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductShowCase1.Models.Classes;


namespace ProductShowCase1.Controllers
{
    public class DealersController : Controller
    {
        Context c = new Context();
        // GET: Dealers
        public ActionResult Index()
        {
            var value = c.Dealers.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult DealersAdd()
        {
            List<SelectListItem> city = new List<SelectListItem>();

            city.Add(new SelectListItem { Text = "Bursa" });
            city.Add(new SelectListItem { Text = "Şanlıurfa" });
            city.Add(new SelectListItem { Text = "İstanbul"});
            city.Add(new SelectListItem { Text = "Ankara"});
            city.Add(new SelectListItem { Text = "İzmir"});

            ViewBag.vle1 = city;
            return View();
        }

        [HttpPost]
        public ActionResult DealersAdd(Dealers d)
        {
            c.Dealers.Add(d);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DealersRemove(int ID)
        {
            var bayi = c.Dealers.Find(ID);
            c.Dealers.Remove(bayi);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DealersBring(int ID)
        {
            List<SelectListItem> city = new List<SelectListItem>();

            city.Add(new SelectListItem { Text = "Bursa" });
            city.Add(new SelectListItem { Text = "Şanlıurfa" });
            city.Add(new SelectListItem { Text = "İstanbul" });
            city.Add(new SelectListItem { Text = "Ankara" });
            city.Add(new SelectListItem { Text = "İzmir" });

            ViewBag.vle1 = city;
            var dealers = c.Dealers.Find(ID);
            return View("DealersBring", dealers);
        }
        public ActionResult DealersUpdate(Dealers d)
        {
            var bayi = c.Dealers.Find(d.DealersID);
            bayi.DealersName = d.DealersName;
            bayi.DealersOwner = d.DealersOwner;
            bayi.DealersNumber = d.DealersNumber;
            bayi.DealersAdress = d.DealersAdress;
            bayi.DealersCity = d.DealersCity;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DealersList()
        {
            return View();
        }


    }
}