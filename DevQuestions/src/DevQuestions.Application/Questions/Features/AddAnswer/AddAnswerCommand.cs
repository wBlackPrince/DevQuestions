using DevQuestions.Application.Abstarctions;
using DevQuestionsContract.Questions;

namespace DevQuestions.Application.Questions.AddAnswer;

public record AddAnswerCommand(Guid QuestionId, AddAnswerDto AddAnswerDto): ICommand;