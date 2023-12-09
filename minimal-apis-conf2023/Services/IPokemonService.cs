using minimal_apis_conf2023.Models.Dto;

namespace minimal_apis_conf2023.Services
{
    public interface IPokemonService
    {
        Task<bool> CreatePokemonAsync(Pokemon pokemon);
        Task<bool> UpdatePokemonAsync(Pokemon pokemon);
        Task<bool> DeletePokemonAsync(int id);
        Task<Pokemon?> GetPokemonAsync(int id);
        Task<IEnumerable<Pokemon>> GetAllPokemonsAsync();
    }
}
