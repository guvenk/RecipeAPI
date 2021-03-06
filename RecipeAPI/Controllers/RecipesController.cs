using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Threading.Tasks;

namespace RecipeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            await _recipeService.Test();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipes();

            if (recipes is null || recipes.Count == 0)
            {
                return NotFound();
            }

            return Ok(recipes);
        }


        [HttpPost]
        public async Task<IActionResult> PostRecipe(RecipeDto recipeDto)
        {
            await _recipeService.CreateRecipe(recipeDto);

            return Ok();
        }
    }
}
