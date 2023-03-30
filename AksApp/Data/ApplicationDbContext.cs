using AksApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace AksApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserCredentials> userCredentials { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> Subcategories { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Pdf> Pdfs { get; set; }
        public DbSet<ProductDescription> UserDescription { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<SubCategory>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
