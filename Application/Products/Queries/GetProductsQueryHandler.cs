using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Products.Queries
{
	public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
	{
		private readonly IProductService _productService;

		public GetProductsQueryHandler(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
		{
			return await _productService.GetProducts();
		}
	}
}
