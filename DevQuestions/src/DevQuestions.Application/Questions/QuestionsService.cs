using DevQuestions.Application.Communication;
using DevQuestions.Application.Database;
using DevQuestions.Application.Questions.Failures.Exceptions;
using DevQuestionsContract.Questions;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevQuestions.Application.Questions;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _repository;
    private readonly ILogger<QuestionsService> _logger;
    private readonly IValidator<CreateQuestionDto> _createQuestionDtoValidator;
    private readonly IValidator<AddAnswerDto> _addAnswerDtoValidator;
    private readonly ITransactionManager _transactionManager;
    private readonly IUsersService _userService;

    public QuestionsService(
        IQuestionsRepository repository,
        ILogger<QuestionsService> logger,
        IValidator<CreateQuestionDto> createQuestionDtoValidator,
        IValidator<AddAnswerDto> addAnswerDtoValidator,
        ITransactionManager transactionManager,
        IUsersService userService
        )
    {
        _repository = repository;
        _logger = logger;
        _createQuestionDtoValidator = createQuestionDtoValidator;
        _addAnswerDtoValidator = addAnswerDtoValidator;
        _transactionManager = transactionManager;
        _userService = userService;
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

    // public async Task AddComment(
    //     Guid questionId,
    //     AddCommentDto request,
    //     CancellationToken cancellationToken)
    // {
    //     //
    // }
}