namespace DevQuestionsContract.Questions;

public record GetQuestionsDto(string search, Guid[] tagIds, int page, int pageSize);