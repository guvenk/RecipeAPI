using AutoMapper;
using DataAccess;
using Models;

namespace Business.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<Version, VersionDto>();
            CreateMap<Property, PropertyDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Media, MediaDto>();
            CreateMap<MetaItem, MetaItemDto>();

            CreateMap<RecipeDto, Recipe>();
            CreateMap<VersionDto, Version>();
            CreateMap<PropertyDto, Property>();
            CreateMap<CommentDto, Comment>();
            CreateMap<MediaDto, Media>();
            CreateMap<MetaItemDto, MetaItem>();
        }
    }
}
