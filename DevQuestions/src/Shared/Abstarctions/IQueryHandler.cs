using CSharpFunctionalExtensions;
using Shared;

namespace DevQuestions.Application.Abstarctions;

public interface IQuery;


public interface IQueryHandler<TResponse, in TQuery>
    where TQuery : IQuery
{
    Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}