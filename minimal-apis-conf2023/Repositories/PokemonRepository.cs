using Dapper;
using minimal_apis_conf2023.DataBase;
using minimal_apis_conf2023.Models.Dto;

namespace minimal_apis_conf2023.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PokemonRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<bool> CreatePokemonAsync(Pokemon pokemon)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"INSERT INTO Pokemons (Name, Type, HealthPoints, Attack, Defense, Speed, EvolveFrom, EvolveTo)
                  VALUES (@Name, @Type, @HealthPoints, @Attack, @Defense, @Speed, @EvolveFrom, @EvolveTo)",
                pokemon);
            return result > 0;
        }

        public async Task<bool> DeletePokemonAsync(int id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(@"DELETE FROM Pokemons WHERE Id = @Id",
                new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemonsAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<Pokemon>("SELECT * FROM Pokemons");
        }

        public async Task<Pokemon?> GetPokemonAsync(int id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<Pokemon>(
                "SELECT * FROM Pokemons WHERE Id = @Id", new { Id = id });
        }

        public async Task<Pokemon?> GetPokemonByNameAsync(string name)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<Pokemon>(
                "SELECT * FROM Pokemons WHERE Name = @Name", new { Name = name });
        }

        public async Task<bool> UpdatePokemonAsync(Pokemon pokemon)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"UPDATE Pokemons SET Name = @Name, Type = @Type, 
                    HealthPoints = @HealthPoints,
                    Attack = @Attack, 
                    Defense = @Defense, 
                    Speed =@Speed, 
                    EvolveFrom = @EvolveFrom,
                    EvolveTo = @EvolveTo 
                    WHERE Id = @Id",
                pokemon);
            return result > 0;
        }
    }
}
