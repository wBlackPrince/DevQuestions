namespace DevQuestionsContract.Questions.Dto;

public record UpdateQuestionsDto(string title, string Body, Guid[] tagIds);