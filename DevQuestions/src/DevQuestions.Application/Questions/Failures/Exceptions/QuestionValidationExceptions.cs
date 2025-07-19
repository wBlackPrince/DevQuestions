using DevQuestions.Application.Exceptions;
using Shared;


namespace DevQuestions.Application.Questions.Failures.Exceptions;

public class QuestionValidationExceptions: BadRequestException
{
    public QuestionValidationExceptions(Error[] errors)
        : base(errors)
    {}
}