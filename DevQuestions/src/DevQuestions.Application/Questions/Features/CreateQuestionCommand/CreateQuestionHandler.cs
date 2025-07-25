using CSharpFunctionalExtensions;
using DevQuestions.Application.Abstarctions;
using DevQuestions.Application.Extensions;
using DevQuestions.Application.Questions.Failures;
using DevQuestionsContract.Questions.Dto;
using DevQuestionsDomain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

namespace DevQuestions.Application.Questions.Features.CreateQuestionCommand;

public class CreateQuestionHandler: ICommandHandler<Guid, CreateQuestionCommand>
{
    private readonly IQuestionsRepository _repository;
    private readonly ILogger<CreateQuestionDto> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;

    public CreateQuestionHandler(
        IQuestionsRepository repository,
        ILogger<CreateQuestionDto> logger,
        IValidator<CreateQuestionDto> validator)
    {
        _repository = repository;
        _logger = logger;
        _validator = validator;
    }


    /// <summary>
    /// Создание вопроса
    /// </summary>
    /// <param name="questionDto">Dto для создания вопроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Id созданного вопроса</returns>
    public async Task<Result<Guid, Failure>> Handle(
        CreateQuestionCommand command,
        CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _validator.ValidateAsync(command.QuestionDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            Error[] errors = validationResult.ToErrors();

            return new Failure(errors);
        }

        // валидация бизнес-логики
        int openUserQuestionsCount = await _repository.GetOpenUserQuestionsAsync(
            command.QuestionDto.UserId,
            cancellationToken);

        var existedQuestion = _repository.GetByIdAsync(Guid.Empty, cancellationToken);

        if (openUserQuestionsCount > 3)
        {
            return Errors.Questions.TooManyQuestions().ToFailure();
        }

        Guid questionId = Guid.NewGuid();

        Question question = new Question(
            questionId,
            command.QuestionDto.Title,
            command.QuestionDto.Text,
            command.QuestionDto.UserId,
            null,
            command.QuestionDto.TagIds.ToList());

        await _repository.AddAsync(question, cancellationToken);

        _logger.LogInformation("Question {QuestionId} created.", questionId);

        return questionId;
    }
}