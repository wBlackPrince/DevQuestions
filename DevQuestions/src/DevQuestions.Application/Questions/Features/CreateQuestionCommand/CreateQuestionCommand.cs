using DevQuestions.Application.Abstarctions;
using DevQuestionsContract.Questions.Dto;

namespace DevQuestions.Application.Questions.Features.CreateQuestionCommand;

public record CreateQuestionCommand(CreateQuestionDto QuestionDto): ICommand;