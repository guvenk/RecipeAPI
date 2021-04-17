using AutoMapper;
using DataAccess;
using Models;
using System;
using System.Collections.Generic;

namespace Business.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>();
            //.ForMember(dest => dest.Id, opts => opts.MapFrom(source => source.Id))
            //.ForMember(dest => dest.Name, opts => opts.MapFrom(source => source.Name))
            //.ForMember(dest => dest.Description, opts => opts.MapFrom(source => source.Description));

            CreateMap<DataAccess.Version, VersionDto>();
            CreateMap<Property, PropertyDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Media, MediaDto>();
            CreateMap<MetaItem, MetaItemDto>();

        }
    }
}
