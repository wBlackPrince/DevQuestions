using CSharpFunctionalExtensions;
using DevQuestions.Application.Extensions;
using DevQuestions.Application.Questions.Failures;
using DevQuestions.Application.Questions.Failures.Exceptions;
using DevQuestionsContract.Questions;
using DevQuestionsDomain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

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

    public async Task<Result<Guid, Failure>> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            Error[] errors = validationResult.ToErrors();

            return new Failure(errors);
        }

        // валидация бизнес-логики
        int openUserQuestionsCount = await _repository.GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);

        var existedQuestion = _repository.GetByIdAsync(Guid.Empty, cancellationToken);

        if (openUserQuestionsCount > 3)
        {
            return Errors.Questions.TooManyQuestions().ToFailure();
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



public class QuestionCalculator
{
    public Result<int, Failure> Calculate()
    {
        // какая-то операция

        return Error.Failure("fail", "fail").ToFailure();
    }
}
