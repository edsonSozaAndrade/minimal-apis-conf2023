using minimal_apis_conf2023.Models.Dto;

namespace minimal_apis_conf2023.Repositories
{
    public interface IPokemonRepository
    {
        Task<bool> CreatePokemonAsync(Pokemon pokemon);
        Task<bool> UpdatePokemonAsync(Pokemon pokemon);
        Task<bool> DeletePokemonAsync(int id);
        Task<Pokemon?> GetPokemonAsync(int id);
        Task<Pokemon?> GetPokemonByNameAsync(string id);
        Task<IEnumerable<Pokemon>> GetAllPokemonsAsync();
    }
}
