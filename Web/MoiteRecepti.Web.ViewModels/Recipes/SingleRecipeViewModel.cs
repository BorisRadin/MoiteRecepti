using AutoMapper;
using MoiteRecepti.Data.Models;
using MoiteRecepti.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoiteRecepti.Web.ViewModels.Recipes
{
    public class SingleRecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string CategoryName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AddedByUserEmail { get; set; }

        public string ImageUrl { get; set; }

        public string Instructions { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookingTime { get; set; }

        public int PortionsCount { get; set; }

        public int CategoryRecipesCount { get; set; }

        public string OriginalUrl { get; set; }

        public IEnumerable<IngredientsViewModel> Ingredients { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, SingleRecipeViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl ?? "/images/" + x.Images.FirstOrDefault().Id + x.Images.FirstOrDefault().Extension));
        }
    }
}
