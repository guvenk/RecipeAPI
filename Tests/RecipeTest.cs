using AutoMapper;
using Business;
using Business.Profiles;
using DataAccess;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class RecipeTest
    {
        private readonly AppDbContext _context;
        private readonly RecipeService _recipeService;
        private readonly IMapper mapper;
        public RecipeTest()
        {
            _context = new AppDbContext(DbContextHelper.GetInMemoryOptions());
            //_recipeService = new RecipeService(_context, Mock.Of<IMapper>());
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new RecipeProfile())));
            _recipeService = new RecipeService(_context, mapper);
        }

        [Fact]
        public async Task Recipes_GetAll_ReturnEmptySet()
        {
            var result = await _recipeService.GetAllRecipes();
            Assert.Empty(result);
        }
    }
}
