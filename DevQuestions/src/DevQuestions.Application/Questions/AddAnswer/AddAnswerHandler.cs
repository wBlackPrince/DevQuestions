using CSharpFunctionalExtensions;
using DevQuestions.Application.Communication;
using DevQuestions.Application.Database;
using DevQuestions.Application.Extensions;
using DevQuestions.Application.Questions.Failures;
using DevQuestionsContract.Questions;
using DevQuestionsDomain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

namespace DevQuestions.Application.Questions.AddAnswer;


public record AddAnswerCommand(Guid QuestionId, AddAnswerDto AddAnswerDto);


public class AddAnswerHandler
{
    private readonly IQuestionsRepository _repository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<AddAnswerDto> _addAnswerDtoValidator;
    private readonly ITransactionManager _transactionManager;
    private readonly IUsersService _userService;


    public AddAnswerHandler(
        IQuestionsRepository repository,
        ILogger<QuestionsService> logger,
        IValidator<AddAnswerDto> addAnswerDtoValidator,
        ITransactionManager transactionManager,
        IUsersService userService)
    {
        _repository = repository;
        _logger = logger;
        _addAnswerDtoValidator = addAnswerDtoValidator;
        _transactionManager = transactionManager;
        _userService = userService;
    }


    public async Task<Result<Guid, Failure>> Handle(
        Guid questionId,
        AddAnswerDto addAnswerDto,
        CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _addAnswerDtoValidator.ValidateAsync(addAnswerDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            Error[] errors = validationResult.ToErrors();

            return new Failure(errors);
        }

        var usersRatingResult = await _userService.GetUserRatingAsync(addAnswerDto.UserId, cancellationToken);

        if (usersRatingResult.IsFailure)
        {
            return usersRatingResult.Error;
        }

        if (usersRatingResult.Value <= 0)
        {
            return Errors.Questions.NotEnoughRating(addAnswerDto.UserId).ToFailure();
        }

        var transaction = await _transactionManager.BeginTransactionAsync(cancellationToken);

        (_, bool isFailure, Question? question, Failure? error) = await _repository.GetByIdAsync(questionId, cancellationToken);

        if (isFailure)
        {
            return error;
        }

        var answer = new Answer(Guid.NewGuid(), addAnswerDto.UserId, addAnswerDto.Text, questionId);

        question.Answers.Add(answer);

        var answerId = await _repository.SaveAsync(question, cancellationToken);

        transaction.Commit();

        _logger.LogInformation("Answer {AnswerId} created.", answerId);

        return answerId;
    }
}