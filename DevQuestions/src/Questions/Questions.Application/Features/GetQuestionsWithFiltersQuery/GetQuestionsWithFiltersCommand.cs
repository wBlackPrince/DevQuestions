using Questions.Contracts.Dto;
using Shared.Abstarctions;

namespace Questions.Application.Features.GetQuestionsWithFiltersQuery;

public record GetQuestionsWithFiltersCommand(GetQuestionsDto Dto): IQuery;