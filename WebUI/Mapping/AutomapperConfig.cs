using AutoMapper;
using Domain.Entities;

namespace WebUI.Mapping
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<Product, ViewModels.Product>().ReverseMap();        
        }
    }
}
