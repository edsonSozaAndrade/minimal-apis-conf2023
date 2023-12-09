using minimal_apis_conf2023.Interfaces;
using minimal_apis_conf2023.Models.Dto;
using minimal_apis_conf2023.Services;
using System.Net;

namespace minimal_apis_conf2023.Endpoints
{
    public class GetAllPokemonsEndpoint : IEndpoint
    {
        private readonly IPokemonService _pokemonService;

        public GetAllPokemonsEndpoint(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task MapEndpoint(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/pokemons", async () => 
            {
                return Results.Ok(await _pokemonService.GetAllPokemonsAsync());
            }).WithOpenApi()
            .WithDescription("Endpoint para obtener la lista de todos los pokémons")
            .Produces<IEnumerable<Pokemon>>((int)HttpStatusCode.OK);
        }
    }
}
