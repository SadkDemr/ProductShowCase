using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductShowCase1.Models.Classes
{
    public class Class1
    {
        public IEnumerable<Category> Kategoriler { get; set; }
        public IEnumerable<Product> Urunler { get; set; }
    }
}