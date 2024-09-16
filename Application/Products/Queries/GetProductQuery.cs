using Domain.Entities;
using MediatR;

namespace Application.Products.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public int ProductId { get; set; }
    }
}
