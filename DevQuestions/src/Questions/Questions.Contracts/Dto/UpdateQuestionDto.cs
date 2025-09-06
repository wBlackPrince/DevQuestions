namespace Questions.Contracts.Dto;

public record UpdateQuestionsDto(string title, string Body, Guid[] tagIds);