using DevQuestionsDomain.Questions;
using DevQuestionsDomain.Tags;

namespace DevQuestions.Application.Questions;

public interface IQuestionsReadDbContext
{
    IQueryable<Question> ReadQuestions { get; }
}