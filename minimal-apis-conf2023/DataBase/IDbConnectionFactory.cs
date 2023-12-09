using System.Data;

namespace minimal_apis_conf2023.DataBase
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
