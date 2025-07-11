namespace DevQuestionsDomain.Questions;

public class Question
{
    public Guid Id { get; set; }
    
    public required string Title { get; set; } = string.Empty;

    public required string Text { get; set; } = string.Empty;

    public required Guid UserId { get; set; }
    
    public List<Answer> Answers {get; set;} = [];

    public Answer? Solution { get; set; } = null;

    public List<Guid> Tags { get; set; } = [];

    public List<Guid> Comments { get; set; } = [];
}