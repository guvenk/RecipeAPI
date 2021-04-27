using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
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

        //{
        //  "id": 0,
        //  "apiVersion": "1.0",
        //  "active": true,
        //  "createdDate": "2021-04-17T15:12:18.999Z",
        //  "versions": [
        //    {
        //      "rating": 0,
        //      "properties": [
        //        {
        //          "value": "Gulash",
        //          "metaItemId": 1
        //        },
        //        {
        //          "value": "cut the beef in small pieces, add vegetables and paprika then mix.",
        //          "metaItemId": 2
        //        },
        //        {
        //    "value": "Hungary",
        //          "metaItemId": 3
        //        },
        //        {
        //    "value": "500 gr beef",
        //          "metaItemId": 6
        //        }
        //      ],
        //      "medias": [
        //      ],
        //      "comments": [
        //        {
        //          "text": "test comment",
        //          "userId": 1,
        //          "createdDate": "2021-04-17T15:12:18.999Z"
        //        }
        //      ],
        //      "createdDate": "2021-04-17T15:12:18.999Z"
        //    }
        //  ]
        //}
        public async Task CreateRecipe(RecipeDto recipeDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);

            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task Test()
        {
            IEnumerable<Property> q = _context.Properties.Where(x => x.Value.StartsWith("G")).Take(2);

            var set = q.ToList();
            //_context.RssBlogs.Add(new RssBlog { Url = "-", RssUrl = "Bomb" });
            //_context.Blogs.Add(new Blog { Url = "-" });

            //await _context.SaveChangesAsync();
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
