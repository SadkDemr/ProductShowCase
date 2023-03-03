using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProductShowCase1.Models.Classes
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Dealers> Dealers { get; set; }
    }
}