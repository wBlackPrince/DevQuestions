using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Questions.Application;
using Shared.Database;
using Shared.FilesStorage;

namespace Questions.Infrastructure.Postgres;

public static class DependencyInjection
{
    public static IServiceCollection AddQuestionInfrastructurePostgres(this IServiceCollection services)
    {
        services.AddDbContext<QuestionsReadDbContext>();
        services.AddScoped<IQuestionsReadDbContext, QuestionsReadDbContext>();
        services.AddScoped<IQuestionsRepository, QuestionsEfCoreRepository>();
        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

        return services;
    }
}