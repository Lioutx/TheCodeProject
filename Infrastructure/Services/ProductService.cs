using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.DTOs;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProduct(int productId)
        {
            ProductDto productDto = await _productRepository.Get(productId);

            return new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Quantity = productDto.Quantity,
                Weight = productDto.Weight,
                BuyAlways = productDto.BuyAlways,
                CookedToUncookedRatio = productDto.CookedToUncookedRatio
            };
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
