using MediatR;

namespace Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
    }
}
