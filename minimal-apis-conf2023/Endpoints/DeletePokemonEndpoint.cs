using minimal_apis_conf2023.Interfaces;
using minimal_apis_conf2023.Services;
using System.Net;

namespace minimal_apis_conf2023.Endpoints
{
    public class DeletePokemonEndpoint : IEndpoint
    {
        private readonly IPokemonService _pokemonService;

        public DeletePokemonEndpoint(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task MapEndpoint(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapDelete("delete", async (int id) => {
                return Results.Ok(await _pokemonService.DeletePokemonAsync(id));
            }).WithOpenApi()
            .WithDescription("Endpoint para eliminar un pokémon basado en un Id")
            .Produces<bool>((int)HttpStatusCode.OK);
        }
    }
}
