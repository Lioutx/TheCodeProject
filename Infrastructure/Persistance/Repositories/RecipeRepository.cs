using Dapper;
using Domain.Aggregates;
using Infrastructure.Config;
using Infrastructure.DTOs;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Infrastructure.Persistance.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ConnectionStrings _connectionStrings;

        public RecipeRepository(IOptionsSnapshot<ConnectionStrings> configuration)
        {
            _connectionStrings = configuration.Value;
        }

        public Task<int?> Create(RecipeDto recipe)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int recipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<RecipeDto> Get(int recipeId)
        {
            if (recipeId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(recipeId));
            }

            using (var connection = new NpgsqlConnection(_connectionStrings.PostgreDB))
            {
                string command = "SELECT * FROM recipe WHERE ID = @recipeId";
                CommandDefinition commandDefinition = new CommandDefinition(command, parameters: new { recipeId });

                RecipeDto recipeDto = await connection.QueryFirstOrDefaultAsync<RecipeDto>(commandDefinition);

                return recipeDto;
            }
        }

        public async Task<List<RecipeDto>> GetAll()
        {
            using (var connection = new NpgsqlConnection(_connectionStrings.PostgreDB))
            {
                string command = "SELECT * FROM recipe";
                CommandDefinition commandDefinition = new CommandDefinition(command);

                IEnumerable<RecipeDto> recipes = await connection.QueryAsync<RecipeDto>(commandDefinition);

                return recipes.ToList();
            }
        }

        public Task<bool> Update(RecipeDto recipe)
        {
            throw new NotImplementedException();
        }
    }
}
