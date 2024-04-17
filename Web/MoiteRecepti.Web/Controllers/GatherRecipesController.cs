using Microsoft.AspNetCore.Mvc;
using MoiteRecepti.Services;
using System.Threading.Tasks;

namespace MoiteRecepti.Web.Controllers
{
    public class GatherRecipesController : BaseController
    {
        private readonly IGotvachBgScraperService gotvachBgScraperService;

        public GatherRecipesController(IGotvachBgScraperService gotvachBgScraperService)
        {
            this.gotvachBgScraperService = gotvachBgScraperService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Add()
        {
            await this.gotvachBgScraperService.ImportRecipesAsync(200, 201);

            return this.Redirect("/");
        }
    }
}
