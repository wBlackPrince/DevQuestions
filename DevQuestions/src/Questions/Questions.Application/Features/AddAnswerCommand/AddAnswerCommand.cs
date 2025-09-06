using Questions.Contracts.Dto;
using Shared.Abstarctions;

namespace Questions.Application.Features.AddAnswerCommand;

public record AddAnswerCommand(Guid QuestionId, AddAnswerDto AddAnswerDto): ICommand;