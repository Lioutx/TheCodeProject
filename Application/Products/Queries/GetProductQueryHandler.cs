using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Products.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IProductService _productService;

        public GetProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProduct(request.ProductId);
        }
    }
}
