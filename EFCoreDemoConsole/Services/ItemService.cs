using EFCoreDemo.Domain.Items;
using EFCoreDemo.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoConsole.Services
{
    public class ItemService
    {
        public async Task<List<ItemDto>> GetListAsync()
        {
            using var db = new EFCoreDemoDbContext();
            var dtos = new List<ItemDto>();
            var items = await db.Items.ToListAsync();
            foreach (var item in items)
            {
                var dto = new ItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Category = db.Categories.Where(x => x.Id == item.CategoryId).FirstOrDefault()?.Name
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task CreateAsync(string? name, int categoryId)
        {
            try
            {
                using var db = new EFCoreDemoDbContext();
                var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == categoryId) ?? throw new Exception();
                var item = new Item
                {
                    Name = name,
                    CategoryId = categoryId
                };

                db.Items.Add(item);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }

    public class ItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
    }
}
