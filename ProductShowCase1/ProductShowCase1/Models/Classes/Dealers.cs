using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductShowCase1.Models.Classes
{
    public class Dealers
    {
        [Key]
        public int DealersID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string DealersName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DealersOwner { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string DealersNumber { get; set; }

        public string DealersAdress { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DealersCity { get; set; }
    }
}