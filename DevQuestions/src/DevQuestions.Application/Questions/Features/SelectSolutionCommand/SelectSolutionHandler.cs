using CSharpFunctionalExtensions;
using DevQuestions.Application.Abstarctions;
using Shared;

namespace DevQuestions.Application.Questions.Features.SelectSolutionCommand;

public class SelectSolutionHandler : ICommandHandler<Guid, SelectSolutionCommand>
{
    public async Task<Result<Guid, Failure>> Handle(SelectSolutionCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}