using AutoMapper;
using Domain.Aggregates;
using Domain.Entities;

namespace Api.Mapping
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<Product, ViewModels.Product>().ReverseMap();        
            CreateMap<Recipe, ViewModels.Recipe>().ReverseMap();        
        }
    }
}
