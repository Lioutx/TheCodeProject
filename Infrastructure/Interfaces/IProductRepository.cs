using Infrastructure.DTOs;

namespace Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDto> Get(int productId);
		Task<List<ProductDto>> GetAll();
	}
}
