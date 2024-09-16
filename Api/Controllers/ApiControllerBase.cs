using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        protected readonly ILogger<ApiControllerBase> _logger;

        public ApiControllerBase(IMediator mediator, IMapper mapper, ILogger<ApiControllerBase> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
    }
}
