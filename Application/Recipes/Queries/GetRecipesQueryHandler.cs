using Application.Common.Interfaces;
using Domain.Aggregates;
using MediatR;

namespace Application.Recipes.Queries
{
    public class GetRecipesQueryHandler : IRequestHandler<GetRecipesQuery, List<Recipe>>
    {
        private readonly IRecipeService _recipeService;

        public GetRecipesQueryHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<List<Recipe>> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
        {
            return await _recipeService.GetRecipes();
        }
    }
}
