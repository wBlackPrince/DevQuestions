using CSharpFunctionalExtensions;
using DevQuestions.Application.Extensions;
using DevQuestions.Application.Questions.Failures;
using DevQuestionsContract.Questions;
using DevQuestionsDomain.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared;

namespace DevQuestions.Application.Questions.CreateQuestion;

public class CreateQuestionHandler
{
    private readonly IQuestionsRepository _repository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _validator;

    public CreateQuestionHandler(
        IQuestionsRepository repository,
        ILogger<QuestionsService> logger,
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
    public async Task<Result<Guid, Failure>> Handle(CreateQuestionDto questionDto, CancellationToken cancellationToken)
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
}