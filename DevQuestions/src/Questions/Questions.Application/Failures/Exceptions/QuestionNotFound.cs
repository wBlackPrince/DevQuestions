using DevQuestions.Application.Exceptions;
using Shared;


namespace DevQuestions.Application.Questions.Failures.Exceptions;

public class QuestionNotFound: NotFoundException
{
    public QuestionNotFound(Error[] errors)
        : base(errors) {}
}