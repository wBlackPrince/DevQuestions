namespace DevQuestionsContract.Questions.Dto;

public record GetQuestionsDto(string search, Guid[] tagIds, int page, int pageSize);