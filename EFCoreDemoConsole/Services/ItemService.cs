using EFCoreDemo.Domain.Items;
using EFCoreDemo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemoConsole.Services
{
    public class ItemService
    {
        public List<ItemDto> GetList()
        {
            using (var db = new EFCoreDemoDbContext())
            {
                var dtos = new List<ItemDto>();
                var items = db.Items.ToList();
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
        }

        public void Create(string name, int categoryId)
        {
            try
            {
                using (var db = new EFCoreDemoDbContext())
                {
                    var category = db.Categories.FirstOrDefault(x => x.Id == categoryId) ?? throw new Exception();
                    var item = new Item
                    {
                        Name = name,
                        CategoryId = categoryId
                    };

                    db.Items.Add(item);
                    db.SaveChanges();
                }
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
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
