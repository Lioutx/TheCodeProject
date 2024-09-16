using Infrastructure.DTOs;

namespace Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDto> Get(int productId);
		Task<List<ProductDto>> GetAll();
        Task<bool> Update(ProductDto product);
        Task<int?> Create(ProductDto product);
        Task<bool> Delete(int productId);
    }
}
