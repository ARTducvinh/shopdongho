using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shopdongho.Models
{
    public class ShopDongHODBContext : DbContext
    {
        public ShopDongHODBContext() : base("name=ChuoiKN") { }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<GioHang> Menus { get; set; }
        public DbSet<Product> Products { get; set; }  
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topic { get; set; }

        public System.Data.Entity.DbSet<shopdongho.Models.DonHang> DonHangs { get; set; }
    }
}