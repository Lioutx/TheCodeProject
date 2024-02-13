using Application.Common.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using Infrastructure.DTOs;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<Recipe> GetRecipe(int Id)
        {
            RecipeDto recipeDto = await _recipeRepository.Get(Id);
            return _mapper.Map<Recipe>(recipeDto);
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            List<RecipeDto> recipes = await _recipeRepository.GetAll();
            return _mapper.Map<List<Recipe>>(recipes);
        }
    }
}
