using Dapper;
using Domain.Entities;
using Infrastructure.Config;
using Infrastructure.DTOs;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Infrastructure.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ConnectionStrings _connectionStrings;

        public ProductRepository(IOptionsSnapshot<ConnectionStrings> configuration)
        {
            _connectionStrings = configuration.Value;
        }

        public async Task<ProductDto> Get(int productId)
        {
            if (productId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productId));
            }

            using (var connection = new NpgsqlConnection(_connectionStrings.PostgreDB))
            {
                string command = "SELECT * FROM product WHERE ID = @productId";
                CommandDefinition commandDefinition = new CommandDefinition(command, parameters: new { productId });

                ProductDto productDto = await connection.QueryFirstOrDefaultAsync<ProductDto>(commandDefinition);

                return productDto;
            }                        
        }

		public async Task<List<ProductDto>> GetAll()
		{
			using (var connection = new NpgsqlConnection(_connectionStrings.PostgreDB))
			{
				string command = "SELECT * FROM product";
				CommandDefinition commandDefinition = new CommandDefinition(command);

                IEnumerable<ProductDto> productsDto = await connection.QueryAsync<ProductDto>(commandDefinition);

				return productsDto.ToList();
			}
		}
	}
}
