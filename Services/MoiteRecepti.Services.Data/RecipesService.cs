namespace MoiteRecepti.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;
    using MoiteRecepti.Services.Mapping;
    using MoiteRecepti.Web.ViewModels;
    using MoiteRecepti.Web.ViewModels.Recipes;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepository;

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IDeletableEntityRepository<Ingredient> ingredientsRepository)
        {
            this.recipesRepository = recipesRepository;
            this.ingredientsRepository = ingredientsRepository;
        }
        public async Task CreateAsync(CreateRecipeInputModel input, string userId)
        {
            var recipe = new Recipe
            {
                CategoryId = input.CategoryId,
                CookingTime = TimeSpan.FromMinutes(input.CookingTime),
                PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
                Instructions = input.Instructions,
                Name = input.Name,
                PortionsCount = input.PortionsCount,
                AddedByUserId = userId,
                Images = input.Images as Image[],

            };

            foreach (var inputIngredient in input.Ingredients)
            {
                var ingredient = this.ingredientsRepository.All().FirstOrDefault(x => x.Name == inputIngredient.IngredientName);
                if (ingredient == null)
                {
                    ingredient = new Ingredient { Name = inputIngredient.IngredientName };
                }

                recipe.Ingredients.Add(new RecipeIngredient
                {
                    Ingredient = ingredient,
                    Quantity = inputIngredient.Quantity,
                });
            }

            var allowedExtensions = new[] { ".jpg", ".png", ".gif" };
            //wwwroot/images/recipes/{id}.{ext}
            //wwwroot/images/recipes/ioushjd-235uhijd-1234.jpg
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName);
                if (!allowedExtensions.Contains(extension))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = int.Parse(userId),
                    Extension = extension,
                };
                recipe.Images.Add(dbImage);

                var physicalPath = $"wwwroot/images/recipes/{dbImage.Id}.{dbImage.Extension}";

                var fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
                fileStream.Close();
            }

            await this.recipesRepository.AddAsync(recipe);
            await this.recipesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var recipes = this.recipesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
            return recipes;
        }

        public int GetCount()
        {
            return this.recipesRepository.All().Count();
        }
    }
}
