namespace DevQuestionsDomain.Questions;

public class Answer
{
    public Answer(Guid id, Guid userId, string text, Guid questionId)
    {
        Id = id;
        UserId = userId;
        Text = text;
        QuestionId = questionId;
    }

    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Text { get; set; } = string.Empty;

    public Question Question { get; set; } = null!;

    public Guid QuestionId { get; set; }

    public List<Guid> Comments { get; set; } = [];

    public long Rating { get; set; }
}