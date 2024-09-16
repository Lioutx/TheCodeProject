using Infrastructure.DTOs;

namespace Infrastructure.Interfaces
{
    public interface IRecipeRepository
    {
        Task<RecipeDto> Get(int recipeId);
        Task<List<RecipeDto>> GetAll();
        Task<bool> Update(RecipeDto recipe);
        Task<int?> Create(RecipeDto recipe);
        Task<bool> Delete(int recipeId);
    }
}
