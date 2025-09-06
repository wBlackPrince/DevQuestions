using CSharpFunctionalExtensions;
using Shared;
using Shared.FullTextSearch;

namespace DevQuestions.Infrastructure.ElasticSearch;


public class ElasticSearchProvider : ISearchProvider
{
    public Task<List<Guid>> SearchAsync(string query) => throw new NotImplementedException();

    public Task<UnitResult<Failure>> IndexQuestionAsync<TEntity>(TEntity entity, string indexName) => throw new NotImplementedException();
}