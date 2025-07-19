using DevQuestions.Application.Exceptions;
using Shared;

namespace DevQuestions.Application.Questions.Failures.Exceptions;

public class TooManyQuestionsErrorException: BadRequestException
{
    public TooManyQuestionsErrorException()
        : base([Errors.Questions.TooManyQuestions()])
    {}
}