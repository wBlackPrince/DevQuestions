using DevQuestions.Application.Abstarctions;
using DevQuestionsContract.Questions.Dto;

namespace DevQuestions.Application.Questions.Features.GetQuestionsWithFiltersQuery;

public record GetQuestionsWithFiltersCommand(GetQuestionsDto Dto): IQuery;