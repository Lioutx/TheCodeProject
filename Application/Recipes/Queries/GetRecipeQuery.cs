using Domain.Aggregates;
using MediatR;

namespace Application.Recipes.Queries
{
    public class GetRecipeQuery : IRequest<Recipe>
    {
        public int RecipeId { get; set; }
    }
}
