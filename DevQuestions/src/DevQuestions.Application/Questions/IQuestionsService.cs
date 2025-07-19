using CSharpFunctionalExtensions;
using DevQuestionsContract.Questions;
using Shared;

namespace DevQuestions.Application.Questions;

public interface IQuestionsService
{
    Task<Result<Guid, Failure>> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken);
}