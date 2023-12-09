using AutoMapper;
using minimal_apis_conf2023.Models.Dto;
using minimal_apis_conf2023.Models.Request;

namespace minimal_apis_conf2023.Mappers
{
    public class PokemonProfile: Profile
    {
        public PokemonProfile()
        {
            CreateMap<CreatePokemonRequest, Pokemon>();
        }
    }
}
