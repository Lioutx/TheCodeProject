using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Task<Product> GetProduct(int productId);
    }
}
