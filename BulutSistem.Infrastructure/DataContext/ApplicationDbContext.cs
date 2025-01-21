

using BulutSistem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BulutSistem.Infrastructure.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        
    }
}
