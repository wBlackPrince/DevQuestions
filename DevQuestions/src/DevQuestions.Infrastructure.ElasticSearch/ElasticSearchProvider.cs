using DevQuestions.Application.FullTextSearch;

namespace DevQuestions.Infrastructure.ElasticSearch;

public class ElasticSearchProvider: ISearchProvider
{
    public Task<List<Guid>> SearchAsync(string query)
    {
        throw new NotImplementedException();
    }
}