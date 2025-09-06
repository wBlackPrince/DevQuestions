//using DevQuestions.Application.Communication;

using FluentValidation;
using Microsoft.Extensions.Logging;
using Questions.Contracts.Dto;
using Shared.Database;

namespace Questions.Application;

// public class QuestionsService : IQuestionsService
// {
//     private readonly IQuestionsRepository _repository;
//     private readonly ILogger<QuestionsService> _logger;
//     private readonly IValidator<CreateQuestionDto> _createQuestionDtoValidator;
//     private readonly IValidator<AddAnswerDto> _addAnswerDtoValidator;
//     private readonly ITransactionManager _transactionManager;
//
//     public QuestionsService(
//         IQuestionsRepository repository,
//         ILogger<QuestionsService> logger,
//         IValidator<CreateQuestionDto> createQuestionDtoValidator,
//         IValidator<AddAnswerDto> addAnswerDtoValidator,
//         ITransactionManager transactionManager)
//     {
//         _repository = repository;
//         _logger = logger;
//         _createQuestionDtoValidator = createQuestionDtoValidator;
//         _addAnswerDtoValidator = addAnswerDtoValidator;
//         _transactionManager = transactionManager;
//     }
//
//     public async Task UpdateQuestion(
//         Guid questionId,
//         UpdateQuestionsDto request,
//         CancellationToken cancellationToken)
//     {
//         //
//     }
//     
//     public async Task DeleteQuestion(
//         Guid questionId,
//         CancellationToken cancellationToken)
//     {
//         //
//     }
//     
//     public async Task SelectSolutionCommand(
//         Guid questionId,
//         Guid answerId,
//         CancellationToken cancellationToken)
//     {
//         //
//     }
//
//     public async Task AddComment(
//         Guid questionId,
//         AddCommentDto request,
//         CancellationToken cancellationToken)
//     {
//         //
//     }
// }