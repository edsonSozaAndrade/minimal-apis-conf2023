using FluentValidation;
using FluentValidation.Results;
using minimal_apis_conf2023.Models.Dto;
using minimal_apis_conf2023.Repositories;

namespace minimal_apis_conf2023.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<bool> CreatePokemonAsync(Pokemon pokemon)
        {
            return await _pokemonRepository.CreatePokemonAsync(pokemon);
        }

        public async Task<bool> DeletePokemonAsync(int id)
        {
            return await _pokemonRepository.DeletePokemonAsync(id);
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemonsAsync()
        {
            return await _pokemonRepository.GetAllPokemonsAsync();
        }

        public async Task<Pokemon?> GetPokemonAsync(int id)
        {
            return await _pokemonRepository.GetPokemonAsync(id);
        }

        public async Task<bool> UpdatePokemonAsync(Pokemon pokemon)
        {
            var pokemonFound = await _pokemonRepository.GetPokemonByNameAsync(pokemon.Name);
            if (pokemonFound != null)
            {
                pokemonFound.Defense = pokemon.Defense;
                pokemonFound.EvolveFrom = pokemon.EvolveFrom;
                pokemonFound.EvolveTo = pokemon.EvolveTo;
                pokemonFound.Attack = pokemon.Attack;
                pokemonFound.Speed = pokemon.Speed;
                pokemonFound.HealthPoints = pokemon.HealthPoints;
                pokemonFound.Type = pokemon.Type;
                pokemonFound.Name = pokemon.Name;
                return await _pokemonRepository.UpdatePokemonAsync(pokemonFound);
            }
            return false;
        }
    }
}
