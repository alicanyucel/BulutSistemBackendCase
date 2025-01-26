using BulutSistem.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BulutSistem.Domain.Repositories;


namespace BulutSistem.Infrastructure.DataContext;

public sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
   

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<Variant> Variants { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // istenmeyen tablolar identity
        builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Entity<Category>()
         .HasOne(c => c.ParentCategory)
         .WithMany(c => c.SubCategories)
         .HasForeignKey(c => c.ParentCategoryId)
         .OnDelete(DeleteBehavior.Restrict);

    }
}