using Domain.Aggregates;
using MediatR;

namespace Application.Recipes.Queries
{
    public class GetRecipesQuery : IRequest<List<Recipe>>
    {        
    }
}
