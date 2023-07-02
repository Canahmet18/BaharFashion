
using Microsoft.EntityFrameworkCore;

namespace BaharFashion.Models
{
    public class BaharFashionEntities : DbContext
    {
        public BaharFashionEntities(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Giyim> Giyims { get; set; }
        public DbSet<Tur> Turs { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }

}