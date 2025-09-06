using Microsoft.Extensions.DependencyInjection;
using Shared.FilesStorage;
using Shared.FullTextSearch;

namespace DevQuestions.Infrastructure.S3;

public static class DependencyInjection
{
    public static IServiceCollection AddS3(this IServiceCollection services)
    {
        services.AddScoped<IFilesProvider, S3Provider>();

        return services;
    }
}