using Application.Common.Interfaces;
using MediatR;

namespace Application.Products.Commands
{
    public class CreateOrUpdateProductCommandHandler : IRequestHandler<CreateOrUpdateProductCommand, bool>
    {
        private readonly IProductService _productService;

        public CreateOrUpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(CreateOrUpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.CreateOrUpdate(request.Product);
            return true;
        }
    }
}
