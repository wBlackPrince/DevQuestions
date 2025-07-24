using DevQuestions.Application.Abstarctions;
using DevQuestions.Application.Questions;
using DevQuestions.Application.Questions.AddAnswer;
using DevQuestions.Application.Questions.CreateQuestion;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DevQuestions.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddScoped<ICommandHandler<Guid, AddAnswerCommand>, AddAnswerHandler>();
        services.AddScoped<ICommandHandler<Guid, CreateQuestionCommand>, CreateQuestionHandler>();

        // var assembly = typeof(DependencyInjection).Assembly;
        //
        // services.Scan(scan => scan.FromAssemblies([assembly])
        //     .AddClasses(classes => classes.
        //         AssignableToAny(typeof(ICommandHandler<,>), typeof(ICommandHandler<>)))
        //     .AsSelfWithInterfaces().WithScopedLifetime());

        return services;
    }
}