using DevQuestionsContract.Questions;
using DevQuestionsDomain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevQuestions.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _repository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;

    public QuestionsService(
        IQuestionsRepository repository,
        ILogger<QuestionsService> logger,
        IValidator<CreateQuestionDto> validator
        )
    {
        _repository = repository;
        _logger = logger;
        _validator = validator;
    }

    public async Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // валидация бизнес-логики
        int openUserQuestionsCount = await _repository.GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);

        if (openUserQuestionsCount > 3)
        {
            throw new ValidationException("Пользователь не может открыть больше 3 нерешенных вопросов");
        }

        Guid questionId = Guid.NewGuid();

        Question question = new Question(
            questionId,
            questionDto.Title,
            questionDto.Text,
            questionDto.UserId,
            null,
            questionDto.TagIds.ToList());

        await _repository.AddAsync(question, cancellationToken);

        _logger.LogInformation("Question {QuestionId} created.", questionId);

        return questionId;
    }

    // public async Task UpdateQuestion(
    //     Guid questionId,
    //     UpdateQuestionsDto request,
    //     CancellationToken cancellationToken)
    // {
    //     //
    // }
    //
    // public async Task DeleteQuestion(
    //     Guid questionId,
    //     CancellationToken cancellationToken)
    // {
    //     //
    // }
    //
    // public async Task SelectSolution(
    //     Guid questionId,
    //     Guid answerId,
    //     CancellationToken cancellationToken)
    // {
    //     //
    // }
    //
    // public async Task AddAnswer(
    //     Guid questionId,
    //     AddAnswerDto request,
    //     CancellationToken cancellationToken)
    // {
    //     //
    // }
    //
    // public async Task AddComment(
    //     Guid questionId,
    //     AddCommentDto request,
    //     CancellationToken cancellationToken)
    // {
    //     //
    // }
}