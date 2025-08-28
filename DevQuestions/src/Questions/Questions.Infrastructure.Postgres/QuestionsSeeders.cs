namespace DevQuestions.Infrastructure.Postgres.Questions;

public class QuestionsSeeders: ISeeder
{
    private readonly QuestionsSeeders _dbContext;

    public QuestionsSeeders(QuestionsSeeders dbContext)
    {
        _dbContext = dbContext;
    }

    public Task SeedAsync()
    {
        throw new NotImplementedException();
    }
}