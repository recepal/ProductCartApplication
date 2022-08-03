using Microsoft.EntityFrameworkCore;
using ProductCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Infrastructure.Database
{
    public class PostgreDbContext : DbContext
    {
        private readonly string _connectionStr = "User ID=postgres; Password=0102; Host=localhost; Port=5432; Database=ProductCardDb; Pooling=false; Timeout=300; CommandTimeout=180;";

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }

        public PostgreDbContext()
        {

        }

        public PostgreDbContext(string connectionStr)
        {
            _connectionStr = connectionStr;
        }

        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionStr);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
