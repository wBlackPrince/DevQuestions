namespace DevQuestion.Contracts;

public record UpdateQuestionsDto(string title, string Body, Guid[] tagIds);