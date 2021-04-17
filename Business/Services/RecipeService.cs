using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class RecipeService : IRecipeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RecipeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateRecipe(RecipeDto recipeDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);

            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RecipeDto>> GetAllRecipes()
        {
            var recipes = await _context.Recipes
                .Include(x => x.Versions)
                    .ThenInclude(x => x.Properties)
                        .ThenInclude(x => x.MetaItem)
                .Include(x => x.Versions)
                    .ThenInclude(x => x.Comments)
                .Include(x => x.Versions)
                    .ThenInclude(x => x.Medias)
                    .ToListAsync();

            var dtos = _mapper.Map<List<RecipeDto>>(recipes);

            return dtos;
        }


    }
}
