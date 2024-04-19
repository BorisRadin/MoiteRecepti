using MoiteRecepti.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoiteRecepti.Data.Seeding
{
    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Супа" });
            await dbContext.Categories.AddAsync(new Category { Name = "Салата" });
            await dbContext.Categories.AddAsync(new Category { Name = "Печено свинско" });
            await dbContext.Categories.AddAsync(new Category { Name = "Пържено свинско" });
            await dbContext.Categories.AddAsync(new Category { Name = "Печено пилешко" });
            await dbContext.Categories.AddAsync(new Category { Name = "Пържено пилешко" });
            await dbContext.Categories.AddAsync(new Category { Name = "Постно" });
            await dbContext.Categories.AddAsync(new Category { Name = "Сандвич" });
            await dbContext.Categories.AddAsync(new Category { Name = "Десерт" });

            await dbContext.SaveChangesAsync();
        }
    }
}
