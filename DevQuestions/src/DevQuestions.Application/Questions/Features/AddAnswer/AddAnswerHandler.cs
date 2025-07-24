using CSharpFunctionalExtensions;
using DevQuestions.Application.Abstarctions;
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

public class AddAnswerHandler: ICommandHandler<Guid, AddAnswerCommand>
{
    private readonly IQuestionsRepository _repository;
    private readonly ILogger<AddAnswerDto> _logger;
    private readonly IValidator<AddAnswerDto> _addAnswerDtoValidator;
    //private readonly ITransactionManager _transactionManager;
    //private readonly IUsersService _userService;


    public AddAnswerHandler(
        IQuestionsRepository repository,
        ILogger<AddAnswerDto> logger,
        IValidator<AddAnswerDto> addAnswerDtoValidator)
    {
        _repository = repository;
        _logger = logger;
        _addAnswerDtoValidator = addAnswerDtoValidator;
    }


    public async Task<Result<Guid, Failure>> Handle(
        AddAnswerCommand command,
        CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _addAnswerDtoValidator.ValidateAsync(command.AddAnswerDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            Error[] errors = validationResult.ToErrors();

            return new Failure(errors);
        }

        // пока не реализовал конкретный класс сервиса пользователя
        // var usersRatingResult = await _userService.GetUserRatingAsync(
        //     command.AddAnswerDto.UserId,
        //     cancellationToken);

        // if (usersRatingResult.IsFailure)
        // {
        //     return usersRatingResult.Error;
        // }
        //
        // if (usersRatingResult.Value <= 0)
        // {
        //     return Errors.Questions.NotEnoughRating(command.AddAnswerDto.UserId).ToFailure();
        // }

        // пока не реализовал конкретный класс транзакции
        //var transaction = await _transactionManager.BeginTransactionAsync(cancellationToken);

        (_, bool isFailure, Question? question, Failure? error) = await _repository
            .GetByIdAsync(command.QuestionId, cancellationToken);

        if (isFailure)
        {
            return error;
        }

        var answer = new Answer(
            Guid.NewGuid(),
            command.AddAnswerDto.UserId,
            command.AddAnswerDto.Text,
            command.QuestionId);

        question.Answers.Add(answer);

        var answerId = await _repository.SaveAsync(question, cancellationToken);

        //transaction.Commit();

        _logger.LogInformation("Answer {AnswerId} created.", answerId);

        return answerId;
    }
}