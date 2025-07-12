namespace DevQuestion.Contracts;

public record GetQuestionsDto(string search, Guid[] tagIds, int page, int pageSize);