using Dapper;
using DevQuestions.Application.Questions;
using DevQuestionsDomain.Questions;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DevQuestions.Infrastructure.Postgres.Repositories;

public class QuestionsSQLRepository: IQuestionsRepository
{
    private readonly SqlConnectionFactory _sqlConnectionFactory;

    public QuestionsSQLRepository(SqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Guid> AddAsync(Question question, CancellationToken cancellationToken)
    {
        const string sql = """
                           INSERT INTO questions (id, title, text, user_id, screenshot_id, tags, status)
                           Values (@Id, @Title, @Text, @UserId, @ScreenshotId, @Tags, @Status)
                           """;
        using var connection = _sqlConnectionFactory.Create();

        await connection.ExecuteAsync(sql,
            new
            {
                Id = question.Id,
                Title = question.Title,
                Text = question.Text,
                UserId = question.UserId,
                ScreenshotId = question.ScreenshotId,
                Tags = question.Tags,
                Status = question.Status
            });

        return question.Id;
    }

    public async Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> DeleteAsync(Guid questionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Question> GetByIdAsync(Guid questionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}