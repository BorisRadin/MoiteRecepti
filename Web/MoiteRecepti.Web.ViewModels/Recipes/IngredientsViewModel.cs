using MoiteRecepti.Data.Models;
using MoiteRecepti.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoiteRecepti.Web.ViewModels.Recipes
{
    public class IngredientsViewModel : IMapFrom<RecipeIngredient>
    {
        public string IngredientName { get; set; }

        public string Quantity { get; set; }
    }
}
