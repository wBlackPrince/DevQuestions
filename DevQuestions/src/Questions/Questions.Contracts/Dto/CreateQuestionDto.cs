namespace DevQuestionsContract.Questions.Dto;

public record CreateQuestionDto(string Title, string Text, Guid UserId, Guid[] TagIds);