using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductShowCase1.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = "Ürün Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Display(Name = "Marka")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Brand { get; set; }

        [Display(Name = "Stok")]
        public short Stock { get; set; }

        [Display(Name = "Alış Fiyatı")]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "Satış Fiyatı")]
        public decimal SalePrice { get; set; }

        [Display(Name = "Durumu")]
        public bool Status { get; set; }

        [Display(Name = "Ürün Görseli-1")]
        public string ProductImage { get; set; }

        [Display(Name = "Ürün Görseli-2")]
        public string ProductImage2 { get; set; }

        [Display(Name = "Ürün Görseli-3")]
        public string ProductImage3 { get; set; }

        [Display(Name = "Ürün Görseli-4")]
        public string ProductImage4 { get; set; }

        [Display(Name = "Ürün Özellikleri")]
        public string ProductFeature { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}