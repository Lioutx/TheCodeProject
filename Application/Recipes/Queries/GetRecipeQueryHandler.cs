using Application.Common.Interfaces;
using Domain.Aggregates;
using MediatR;

namespace Application.Recipes.Queries
{
    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, Recipe>
    {
        private readonly IRecipeService _recipeService;

        public GetRecipeQueryHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<Recipe> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            return await _recipeService.GetRecipe(request.RecipeId);
        }
    }
}
