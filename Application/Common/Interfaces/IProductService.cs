using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
