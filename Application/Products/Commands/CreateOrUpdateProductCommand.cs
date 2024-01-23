using Domain.Entities;
using MediatR;

namespace Application.Products.Commands
{
    public class CreateOrUpdateProductCommand : IRequest<bool>
    {
        public Product Product { get; set; }
    }
}
