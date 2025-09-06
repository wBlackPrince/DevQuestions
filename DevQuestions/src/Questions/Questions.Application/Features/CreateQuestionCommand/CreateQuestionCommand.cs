using Questions.Contracts.Dto;
using Shared.Abstarctions;

namespace Questions.Application.Features.CreateQuestionCommand;

public record CreateQuestionCommand(CreateQuestionDto QuestionDto): ICommand;