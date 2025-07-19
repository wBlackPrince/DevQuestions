

using Shared;

namespace DevQuestions.Application.Questions.Failures;

public partial class Errors
{
    public static class Questions
    {
        public static Error TooManyQuestions() =>
            Error.Failure(
                "questions.TooMany",
                "Пользователь не может открыть больше 3 нерешенных вопросов"
            );
    }
}