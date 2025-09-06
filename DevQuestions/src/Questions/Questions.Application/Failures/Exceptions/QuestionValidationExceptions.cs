using Shared;
using Shared.Exceptions;

namespace Questions.Application.Failures.Exceptions;

public class QuestionValidationExceptions: BadRequestException
{
    public QuestionValidationExceptions(Error[] errors)
        : base(errors)
    {}
}