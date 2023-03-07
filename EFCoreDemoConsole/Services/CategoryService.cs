using EFCoreDemo.Domain.Categories;
using EFCoreDemo.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoConsole.Services
{
    public class CategoryService
    {
        public List<Category> GetList()
        {
            using (var db = new EFCoreDemoDbContext())
            {
                var categories = db.Categories.ToList();
                return categories;
            }
        }

        public void Create(string name)
        {
            using (var db = new EFCoreDemoDbContext())
            {
                var category = new Category { Name = name };
                _ = db.Categories.Add(category);
                db.SaveChanges();
            }
        }
    }
}
