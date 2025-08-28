using DevQuestionsContract.Questions.Dto;

namespace DevQuestionsContract.Questions.Responses;

public record QuestionResponse(IEnumerable<QuestionDto> Questions, long TotalCount);