using EFCoreDemo.Domain.Categories;
using EFCoreDemo.Domain.Items;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.EntityFramework
{
    public class EFCoreDemoDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=EFCoreDemo;Integrated Security=True;MultipleActiveResultSets=true;Trusted_Connection=true;TrustServerCertificate=True");
        }
    }
}
