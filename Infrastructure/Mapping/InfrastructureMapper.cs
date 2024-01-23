using AutoMapper;
using Domain.Entities;
using Infrastructure.DTOs;

namespace Infrastructure.Mapping
{
    public class InfrastructureMapper : Profile
    {
        public InfrastructureMapper() 
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}