using Shared.Exceptions;

namespace Questions.Application.Failures.Exceptions;

public class TooManyQuestionsErrorException: BadRequestException
{
    public TooManyQuestionsErrorException()
        : base([Errors.Questions.TooManyQuestions()])
    {}
}