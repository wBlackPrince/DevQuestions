using DevQuestions.Application.Abstarctions;
using DevQuestionsContract.Questions.Dto;

namespace DevQuestions.Application.Questions.Features.AddAnswerCommand;

public record AddAnswerCommand(Guid QuestionId, AddAnswerDto AddAnswerDto): ICommand;