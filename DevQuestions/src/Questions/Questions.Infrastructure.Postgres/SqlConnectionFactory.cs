using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Shared.Database;

namespace Questions.Infrastructure.Postgres;

public class SqlConnectionFactory: ISqlConnectionFactory
{
    IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection Create()
    {
        var connection = new NpgsqlConnection(
            _configuration.GetConnectionString("DatabaseConnection"));

        return connection;
    }
}