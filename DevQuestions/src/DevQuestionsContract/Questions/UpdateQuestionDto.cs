namespace DevQuestionsContract.Questions;

public record UpdateQuestionsDto(string title, string Body, Guid[] tagIds);