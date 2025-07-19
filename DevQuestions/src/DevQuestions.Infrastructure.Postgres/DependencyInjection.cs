using DevQuestions.Application;
using DevQuestions.Application.Database;
using DevQuestions.Application.Questions;
using DevQuestions.Infrastructure.Postgres.Repositories;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DevQuestions.Infrastructure.Postgres;

public static class DependencyInjection
{
    public static IServiceCollection AddPostrgresInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
        services.AddScoped<QuestionsDbContext>();
        services.AddScoped<IQuestionsRepository, QuestionsEfCoreRepository>();
        services.AddScoped<IQuestionsRepository, QuestionsEfCoreRepository>();

        return services;
    }
}