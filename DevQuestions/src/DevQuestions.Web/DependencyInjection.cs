using DevQuestions.Infrastructure.ElasticSearch;
using DevQuestions.Infrastructure.S3;
using Questions.Presenters;
using Shared;
using Tags.Presenters;

namespace DevQuestions.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
        services.AddQuestionsModule();
        services.AddTagsModule();
        services.AddElasticSearch();
        services.AddS3();
        services.AddWebDependencies();

        return services;
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }
}