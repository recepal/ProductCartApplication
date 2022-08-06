using Microsoft.EntityFrameworkCore;
using ProductCart.Domain.Models;

namespace ProductCart.Infrastructure.Database
{
    public class PostgreDbContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }


        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
        {

        }

    
    }
}
