using AutoMapper;
using minimal_apis_conf2023.Interfaces;
using minimal_apis_conf2023.Models.Dto;
using minimal_apis_conf2023.Models.Request;
using minimal_apis_conf2023.Services;
using System.Net;

namespace minimal_apis_conf2023.Endpoints
{
    public class UpdatePokemonEndpoint : IEndpoint
    {
        private readonly IPokemonService _pokemonService;
        private readonly IMapper _mapper;

        public UpdatePokemonEndpoint(IPokemonService pokemonService, IMapper mapper)
        {
            _pokemonService = pokemonService;
            _mapper = mapper;
        }

        public async Task MapEndpoint(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPut("edit", async (CreatePokemonRequest request) =>
            {
                return Results.Ok(await _pokemonService.UpdatePokemonAsync(_mapper.Map<Pokemon>(request)));
            }).WithOpenApi()
            .WithDescription("Endpoint para actualizar la información de un pokémon existente")
            .Accepts<Pokemon>("application/json")
            .Produces<bool>((int)HttpStatusCode.OK);
        }
    }
}
