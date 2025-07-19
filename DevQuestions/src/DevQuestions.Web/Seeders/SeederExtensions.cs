﻿using DevQuestions.Infrastructure.Postgres.Seeders;

namespace DevQuestions.Web.Seeders;

public static class SeederExtensions
{
    public static async Task<WebApplication> UseSeeders(this WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();

        var seeders = scope.ServiceProvider.GetServices<ISeeder>();

        foreach (var seeder in seeders)
        {
            await seeder.SeedAsync();
        }

        return app;
    }
}