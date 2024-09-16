using Api.ViewModels;
using Application.Recipes.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class RecipeController : ApiControllerBase
    {
        public RecipeController(IMediator mediator, IMapper mapper, ILogger<ApiControllerBase> logger) : base(mediator, mapper, logger)
        {
        }

        [HttpGet, Route("get-all")]
        public async Task<List<Recipe>> GetAll()
        {
            List<Domain.Aggregates.Recipe> recipes = await _mediator.Send(new GetRecipesQuery());
            List<Recipe> response = _mapper.Map<List<ViewModels.Recipe>>(recipes);
            return response;
        }
    }
}
