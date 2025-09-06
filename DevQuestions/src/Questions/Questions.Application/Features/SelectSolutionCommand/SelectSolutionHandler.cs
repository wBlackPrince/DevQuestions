using CSharpFunctionalExtensions;
using Shared;
using Shared.Abstarctions;

namespace Questions.Application.Features.SelectSolutionCommand;

public class SelectSolutionHandler : ICommandHandler<Guid, SelectSolutionCommand>
{
    public async Task<Result<Guid, Failure>> Handle(SelectSolutionCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}