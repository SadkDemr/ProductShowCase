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

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Status { get; set; }
        public string ProductImage { get; set; }
        public string ProductFeature { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}