using Api.ViewModels;
using Application.Products.Commands;
using Application.Products.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ProductController : ApiControllerBase
    {
        public ProductController(IMediator mediator, IMapper mapper, ILogger<ApiControllerBase> logger) : base(mediator, mapper, logger)
        {
        }

        [HttpGet, Route("get-all")]
        public async Task<List<Product>> GetAll()
        {
            List<Domain.Entities.Product> products = await _mediator.Send(new GetProductsQuery());
            List<Product> response = _mapper.Map<List<ViewModels.Product>>(products);
            return response;
        }

        [HttpGet, Route("get/{id}")]
        public async Task<Product> GetProduct([FromRoute] int id)
        {
            Domain.Entities.Product product = await _mediator.Send(new GetProductQuery() { ProductId = id });
            Product response = _mapper.Map<ViewModels.Product>(product);
            return response;
        }

        [HttpPost, Route("create-or-update")]
        public async Task<OkObjectResult> CreateOrUpdate(Product product)
        {
            CreateOrUpdateProductCommand command = new CreateOrUpdateProductCommand();
            command.Product = _mapper.Map<Domain.Entities.Product>(product);

            bool success = await _mediator.Send(command);
            return Ok(success);
        }

    }
}
