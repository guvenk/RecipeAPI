using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetAllRecipes();
        Task CreateRecipe(RecipeDto recipeDto);

        Task Test();

    }
}
