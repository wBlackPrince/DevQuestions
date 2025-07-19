using System.Data;
using DevQuestions.Application;
using DevQuestions.Application.Database;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DevQuestions.Infrastructure.Postgres;

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