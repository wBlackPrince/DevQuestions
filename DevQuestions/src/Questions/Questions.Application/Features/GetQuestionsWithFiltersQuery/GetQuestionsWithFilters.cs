using Dapper;
using DevQuestions.Application.Abstarctions;
using DevQuestions.Application.Database;
using DevQuestions.Application.FilesStorage;
using DevQuestions.Application.Tags;
using DevQuestionsContract.Questions.Dto;
using DevQuestionsContract.Questions.Responses;
using DevQuestionsDomain.Questions;
using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Application.Questions.Features.GetQuestionsWithFiltersQuery;

public class GetQuestionsWithFilters: IQueryHandler<QuestionResponse, GetQuestionsWithFiltersCommand>
{
    private readonly IFilesProvider _filesProvider;
    private readonly ITagsReadDbContext _tagsDbContext;
    private readonly IQuestionsReadDbContext _questionsDbContext;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetQuestionsWithFilters(
        IQuestionsReadDbContext questionsDbContext,
        ISqlConnectionFactory sqlConnectionFactory,
        IFilesProvider filesProvider,
        ITagsReadDbContext tagsDbContext)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _questionsDbContext = questionsDbContext;
        _filesProvider = filesProvider;
        _tagsDbContext = tagsDbContext;
    }

    public async Task<QuestionResponse> Handle(
        GetQuestionsWithFiltersCommand command,
        CancellationToken cancellationToken)
    {
        // если мы работаем с dapper-ом
        // var connection = _sqlConnectionFactory.Create();
        // connection.ExecuteReader("Select * From [Questions]");

        var questions = await _questionsDbContext.ReadQuestions
            .Include(q => q.Solution)
            .Skip(command.Dto.page * command.Dto.pageSize)
            .Take(command.Dto.pageSize)
            .ToListAsync(cancellationToken);

        long count = await _questionsDbContext.ReadQuestions.LongCountAsync(cancellationToken);

        var screenshotIds = questions
            .Where(q => q.ScreenshotId is not null)
            .Select(q => q.ScreenshotId!.Value);

        var filesDict = _filesProvider.GetUrlsByIdsAsync(screenshotIds, cancellationToken);

        var questionTags = questions.SelectMany(q => q.Tags);

        var tags = await _tagsDbContext.ReadTags
            .Where(t => questionTags.Contains(t.Id))
            .Select(t => t.Name)
            .ToListAsync();

        var questionsDto = questions.Select(q => new QuestionDto(
            q.Id,
            q.Title,
            q.Text,
            q.UserId,
            q.ScreenshotId is not null ? filesDict.Result[q.ScreenshotId.Value] : null,
            q.Solution.Id,
            tags,
            q.Status.ToгRussianString()));


        return new QuestionResponse(questionsDto, count);
    }
}