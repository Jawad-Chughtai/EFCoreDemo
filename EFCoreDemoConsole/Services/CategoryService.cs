using EFCoreDemo.Domain.Categories;
using EFCoreDemo.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoConsole.Services
{
    public class CategoryService
    {
        public async Task<List<Category>> GetListAsync()
        {
            using var db = new EFCoreDemoDbContext();
            var categories = await db.Categories.ToListAsync();
            return categories;
        }

        public async Task CreateAsync(string? name)
        {
            using var db = new EFCoreDemoDbContext();
            var category = new Category { Name = name };
            _ = db.Categories.Add(category);
            await db.SaveChangesAsync();
        }
    }
}
