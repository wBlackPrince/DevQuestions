namespace DevQuestionsDomain.Comments;

public class Comment
{
    public Guid Id { get; set; }
    
    public required Guid UserId { get; set; }
    
    public required Guid EntityId { get; set; }
    
    public Comment? Parent { get; set; }
    
    public List<Guid> Children { get; set; } = [];
}