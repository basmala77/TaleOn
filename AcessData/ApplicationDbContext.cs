using AccessData.Configuration;
using AcessData.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Reflection.Emit;

namespace AccessData
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Child> childUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
                base.OnModelCreating(builder);
            // Configure the IdentityRole entity
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.Entity<Child>()
         .HasOne(c => c.Parent)
         .WithMany(p => p.Children)
         .HasForeignKey(c => c.ParentId)
         .OnDelete(DeleteBehavior.Cascade);

         builder.Entity<Child>()
        .HasOne(c => c.Image)
        .WithMany()
        .HasForeignKey(c => c.ImageId)
        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}