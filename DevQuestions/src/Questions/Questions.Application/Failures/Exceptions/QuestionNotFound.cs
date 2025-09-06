using Shared;
using Shared.Exceptions;

namespace Questions.Application.Failures.Exceptions;

public class QuestionNotFound: NotFoundException
{
    public QuestionNotFound(Error[] errors)
        : base(errors) {}
}