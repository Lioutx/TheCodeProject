using AutoMapper;
using Domain.Aggregates;
using Domain.Entities;
using Infrastructure.DTOs;

namespace Infrastructure.Mapping
{
    public class InfrastructureMapper : Profile
    {
        public InfrastructureMapper() 
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<RecipeDto, Recipe>().ReverseMap();
        }
    }
}