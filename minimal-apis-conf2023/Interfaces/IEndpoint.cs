namespace minimal_apis_conf2023.Interfaces
{
    public interface IEndpoint
    {
        Task MapEndpoint(IEndpointRouteBuilder endpoints);
    }
}
