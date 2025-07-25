using CSharpFunctionalExtensions;
using DevQuestions.Application.Communication;
using Shared;

namespace DEvQuestions.Infrastructure.Communication;

public class UserService : IUsersService
{
    public async Task<Result<long, Failure>> GetUserRatingAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}