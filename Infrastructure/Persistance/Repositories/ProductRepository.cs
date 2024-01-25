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

        public async Task<bool> Update(ProductDto product)
        {
            using (var connection = new NpgsqlConnection(_connectionStrings.PostgreDB))
            {
                string command = "UPDATE product SET Name=@name, MeasurementUnit=@measurementUnit, MeasurementValue=@measurementValue, BuyAlways=@buyAlways, CookedToUncookedRatio=@cookedToUncookedRatio WHERE ID = @id";
                
                CommandDefinition commandDefinition = new CommandDefinition(command, parameters: new { product.Id, product.Name, product.MeasurementUnit, product.MeasurementValue, product.BuyAlways, product.CookedToUncookedRatio });

                await connection.QueryFirstOrDefaultAsync(commandDefinition);

                return true;
            }
        }

        public async Task<int?> Create(ProductDto product)
        {
            using (var connection = new NpgsqlConnection(_connectionStrings.PostgreDB))
            {
                string command = "INSERT INTO product (Name, MeasurementUnit, MeasurementValue, BuyAlways, CookedToUncookedRatio) VALUES (@name, @measurementUnit, @measurementValue, @buyAlways, @cookedToUncookedRatio) RETURNING Id";
                
                CommandDefinition commandDefinition = new CommandDefinition(command, parameters: new { product.Id, product.Name, product.MeasurementUnit, product.MeasurementValue, product.BuyAlways, product.CookedToUncookedRatio });

                return await connection.QueryFirstOrDefaultAsync<int?>(commandDefinition);
            }
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

		public async Task<bool> Delete(int productId)
		{
            if (productId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productId));
            }

            using (var connection = new NpgsqlConnection(_connectionStrings.PostgreDB))
            {
                string command = "DELETE FROM product WHERE ID = @productId";
                CommandDefinition commandDefinition = new CommandDefinition(command, parameters: new { productId });

                int affectedRows = await connection.ExecuteAsync(commandDefinition);

                return affectedRows > 0;
            }
        }
    }
}
