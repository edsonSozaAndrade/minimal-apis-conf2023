using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using minimal_apis_conf2023.Filters;
using minimal_apis_conf2023.Interfaces;
using minimal_apis_conf2023.Models.Dto;
using minimal_apis_conf2023.Models.Request;
using minimal_apis_conf2023.Services;
using System.Net;

namespace minimal_apis_conf2023.Endpoints
{
    public class CreatePokemonEndpoint : IEndpoint
    {
        private readonly IPokemonService _pokemonService;
        private readonly IMapper _mapper;

        public CreatePokemonEndpoint(IPokemonService pokemonService, IMapper mapper)
        {
            _pokemonService = pokemonService;
            _mapper = mapper;
        }

        public async Task MapEndpoint(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/create", async (CreatePokemonRequest request) => {
                return Results.Ok(await _pokemonService.CreatePokemonAsync(_mapper.Map<Pokemon>(request)));
            }).AddEndpointFilterFactory(AuditParamsFilter.RequestParamsAudit)
              .WithOpenApi()
              .WithDescription("Endpoint para crear un nuevo pokémon")
              .Accepts<CreatePokemonRequest>("application/json")
              .Produces<bool>((int)HttpStatusCode.OK);
        }
    }
}
