using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantMVC.Models;
using RestaurantMVC.Mapper;

namespace RestaurantMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryType> CategoryTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryType>()
                .HasKey(c => c.Id);
            builder.Entity<CategoryType>()
                .Property(c => c.Name).IsRequired();
            builder.Entity<CategoryType>()
                .Property(c => c.DisplayOrder).IsRequired();
                
                

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<RestaurantMVC.Mapper.CategoryTypeDTO> CategoryTypeDTO { get; set; }
    }
}
