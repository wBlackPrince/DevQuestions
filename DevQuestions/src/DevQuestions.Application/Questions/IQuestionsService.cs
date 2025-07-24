using CSharpFunctionalExtensions;
using DevQuestionsContract.Questions;
using Shared;

namespace DevQuestions.Application.Questions;

public interface IQuestionsService
{
    /// <summary>
    /// Создание вопроса
    /// </summary>
    /// <param name="questionDto">Dto для создания вопроса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Id созданного вопроса.</returns>
    Task<Result<Guid, Failure>> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken);

    /// <summary>
    /// Создание ответа на вопрос
    /// </summary>
    /// <param name="questionId">Id вопроса.</param>
    /// <param name="addAnswerDto">Dto для добавленич ответа на вопрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Результат работы метода.</returns>
    Task<Result<Guid, Failure>> AddAnswer(Guid questionId, AddAnswerDto addAnswerDto, CancellationToken cancellationToken);
}