using Microsoft.EntityFrameworkCore;
using Questions.Contracts.Dto;
using Questions.Contracts.Responses;
using Questions.Domain;
using Shared.Abstarctions;
using Shared.Database;
using Shared.FilesStorage;
using Tags.Contracts;
using Tags.Contracts.Dtos;

namespace Questions.Application.Features.GetQuestionsWithFiltersQuery;

public class GetQuestionsWithFilters: IQueryHandler<QuestionResponse, GetQuestionsWithFiltersCommand>
{
    private readonly IFilesProvider _filesProvider;
    private readonly ITagsContract _tagsContract;
    private readonly IQuestionsReadDbContext _questionsDbContext;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetQuestionsWithFilters(
        IQuestionsReadDbContext questionsDbContext,
        ISqlConnectionFactory sqlConnectionFactory,
        IFilesProvider filesProvider,
        ITagsContract tagsContract)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _questionsDbContext = questionsDbContext;
        _filesProvider = filesProvider;
        _tagsContract = tagsContract;
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

        var tags = await _tagsContract.GetByIds(
            new GetByIdsDto(questionTags.ToArray()));

        var questionsDto = questions.Select(q => new QuestionDto(
            q.Id,
            q.Title,
            q.Text,
            q.UserId,
            q.ScreenshotId is not null ? filesDict.Result[q.ScreenshotId.Value] : null,
            q.Solution.Id,
            tags.Select(t => t.Name),
            q.Status.ToгRussianString()));


        return new QuestionResponse(questionsDto, count);
    }
}