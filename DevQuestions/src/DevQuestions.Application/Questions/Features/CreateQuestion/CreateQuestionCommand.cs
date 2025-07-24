using DevQuestions.Application.Abstarctions;
using DevQuestionsContract.Questions;

namespace DevQuestions.Application.Questions.CreateQuestion;

public record CreateQuestionCommand(CreateQuestionDto QuestionDto): ICommand;