using Domain.Aggregates;

namespace Application.Common.Interfaces
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipe(int Id);
        Task<List<Recipe>> GetRecipes();
    }
}
