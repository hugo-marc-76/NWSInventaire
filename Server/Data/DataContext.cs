using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NWSInventaire.Shared.Models;

namespace NWSInventaire.Server.Data
{
    public class DataContext : DbContext
    {
        public static bool Migrated;

        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<MaterialCategorie>()
                .HasOne(a => a.material)
                .WithOne(a => a.MaterialCategorie)
                .HasForeignKey<Material>(c => c.MaterialId);*/
        }


        public DbSet<Material>? materials { get; set; }

        public DbSet<Student>? students { get; set; }

        public DbSet<MaterialCategorie>? materialCategories { get; set; }

    }
}
