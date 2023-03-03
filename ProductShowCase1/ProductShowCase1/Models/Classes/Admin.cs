using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductShowCase1.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string AdminUserName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string AdminPass { get; set; }
    }
}