using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int productId);
        Task<bool> CreateOrUpdate(Product product);
    }
}
