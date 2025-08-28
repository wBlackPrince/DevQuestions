namespace DevQuestionsDomain.Questions;

public enum QuestionStatus
{
    /// <summary>
    /// Статус открыт.
    /// </summary>
    OPEN,

    /// <summary>
    /// Статус отклонен.
    /// </summary>
    DISMISSED,
}


public static class QuestionStatusExtensions
{
    public static string ToгRussianString(this QuestionStatus status) =>
        status switch
        {
            QuestionStatus.OPEN => "Открыт",
            QuestionStatus.DISMISSED => "Решен",
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
}