

using Shared;

namespace DevQuestions.Application.Questions.Failures;

public partial class Errors
{
    public static class General
    {
        public static Error NotFound(Guid id) =>
            Error.Failure(
                "record.NotFound",
                $"Запись не найдена по идентификатору {id}");
    }

    public static class Questions
    {
        public static Error TooManyQuestions() =>
            Error.Failure(
                "questions.TooMany",
                "Пользователь не может открыть больше 3 нерешенных вопросов");

        public static Error NotEnoughRating(Guid userId) =>
            Error.Failure(
                "questions.NotEnoughRating",
                $"Пользователь c идентификатором {userId} не имеет достаточной репутации чтобы создать ответ");
    }
}