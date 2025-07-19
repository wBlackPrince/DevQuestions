using CSharpFunctionalExtensions;
using DevQuestions.Application.FullTextSearch;
using DevQuestionsDomain.Questions;
using Shared;

namespace DevQuestions.Infrastructure.ElasticSearch;

public class ElasticSearchProvider: ISearchProvider
{
    public Task<List<Guid>> SearchAsync(string query)
    {
        throw new NotImplementedException();
    }

    public async Task<UnitResult<Failure>> IndexQuestionsId(Question question)
    {
        try
        {
            // _elastic.Search()
        }
        catch(Exception ex)
        {
            return Error.Failure("search.failure", ex.Message).ToFailure();
        }

        return UnitResult.Success<Failure>();
    }
}