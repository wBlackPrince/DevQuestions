using CSharpFunctionalExtensions;
using Questions.Application;
using Questions.Application.Failures;
using Questions.Domain;
using Shared;
using Microsoft.EntityFrameworkCore;

namespace Questions.Infrastructure.Postgres;

public class QuestionsEfCoreRepository: IQuestionsRepository
{
    private readonly QuestionsReadDbContext _readDbContext;

    public QuestionsEfCoreRepository(QuestionsReadDbContext context)
    {
        _readDbContext = context;
    }

    public async Task<Guid> AddAsync(Question question, CancellationToken cancellationToken)
    {
        await _readDbContext.Questions.AddAsync(question, cancellationToken);

        await _readDbContext.SaveChangesAsync(cancellationToken);

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

    public async Task<Result<Question, Failure>> GetByIdAsync(Guid questionId, CancellationToken cancellationToken)
    {
        var question = await _readDbContext.Questions
            .Include(q => q.Answers)
            .Include(q => q.Solution)
            .FirstOrDefaultAsync(q => q.Id == questionId, cancellationToken);

        if (question is null)
        {
            return Errors.General.NotFound(questionId).ToFailure();
        }

        return question;
    }

    public async Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddAnswerAsync(Answer answer, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}