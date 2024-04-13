namespace MoiteRecepti.Web.Controllers
{
    using System.Diagnostics;

    using MoiteRecepti.Web.ViewModels;
    using MoiteRecepti.Web.ViewModels.Home;

    using Microsoft.AspNetCore.Mvc;
    using MoiteRecepti.Data;
    using System.Linq;

    public class HomeController : BaseController
    {
        private ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var viewmodel = new IndexViewModel
            {
                CategoriesCount = this.db.Categories.Count(),
                ImagesCount = this.db.Images.Count(),
                IngredientsCount = this.db.Ingredients.Count(),
                RecipesCount = this.db.Recipes.Count(),
            };

            return this.View(viewmodel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
