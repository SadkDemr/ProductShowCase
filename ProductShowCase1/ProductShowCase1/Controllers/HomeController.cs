using ProductShowCase1.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductShowCase1.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Kategoriler = c.Categories.ToList();
            return View(cs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPass == p.AdminPass);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AdminUserName, false);
                Session["AdminUserName"] = bilgiler.AdminUserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Home"); 
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ProductList(int? id)
        {
            Class1 cs = new Class1();
            cs.Kategoriler = c.Categories.ToList();
            cs.Urunler = c.Products.Where(x => x.Status == true).ToList();

            if(id == null)
            {
                cs.Urunler = c.Products.Where(x => x.Status == true).ToList();
            }
            else
            {
                cs.Urunler = c.Products.Where(x => x.Status == true).Where(x => x.CategoryID == id).ToList();
            }


            var products = c.Products.Where(x => x.Status == true).ToList();
            return View(cs);
        }

        public ActionResult ProductDetail(int id)
        {
            var value = c.Products.Where(x => x.ProductID == id).ToList();
            return View(value);
        }

        public ActionResult DealersList()
        {
            var value = c.Dealers.ToList();
            return View(value);
        }
    }
}