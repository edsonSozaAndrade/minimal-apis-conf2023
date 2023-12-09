using Microsoft.AspNetCore.Http;
using minimal_apis_conf2023.Filters;
using minimal_apis_conf2023.Interfaces;
using minimal_apis_conf2023.Models.Dto;
using minimal_apis_conf2023.Services;
using System.Net;

namespace minimal_apis_conf2023.Endpoints
{
    public class GetPokemonEndpoint : IEndpoint
    {
        private readonly IPokemonService _pokemonService;

        public GetPokemonEndpoint(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        public async Task MapEndpoint(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("pokemon/{id:int}", async (int Id) => {
                return Results.Ok(await _pokemonService.GetPokemonAsync(Id));
            }).AddEndpointFilterFactory(AuditPathFilter.RequestAudit)
            .WithOpenApi()
            .WithDescription("Endpoint para obtener un pokémon basado en un Id")
            .Produces((int)HttpStatusCode.BadRequest)
            .Produces<Pokemon>((int)HttpStatusCode.OK);
        }
    }
}
