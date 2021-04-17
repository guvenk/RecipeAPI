using Business;
using DataAccess;
using Xunit;

namespace Tests
{
    public class RecipeTest
    {
        private readonly AppDbContext _context;
        private readonly RecipeService _recipeService;

        public RecipeTest()
        {
            _context = new AppDbContext(DbContextHelper.GetInMemoryOptions());
            _recipeService = new RecipeService(_context,);
        }

        [Fact]
        public void Recipes_GetAll_ReturnEmptySet()
        {

        }
    }
}
