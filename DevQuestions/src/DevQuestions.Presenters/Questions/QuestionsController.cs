using DevQuestions.Application.Abstarctions;
using DevQuestions.Application.Questions;
using DevQuestions.Application.Questions.Features.AddAnswerCommand;
using DevQuestions.Application.Questions.Features.CreateQuestionCommand;
using DevQuestions.Application.Questions.Features.GetQuestionsWithFiltersQuery;
using DevQuestions.Presenters.ResponseExtensions;
using DevQuestionsContract.Questions;
using DevQuestionsContract.Questions.Dto;
using DevQuestionsContract.Questions.Responses;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace DevQuestions.Presenters.Questions;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICommandHandler<Guid, CreateQuestionCommand> handler,
        [FromBody] CreateQuestionDto request,
        CancellationToken cancellationToken)
    {
        var command = new CreateQuestionCommand(request);

        var result = await handler.Handle(command, cancellationToken);

        return result.IsFailure ? result.Error.ToResponse() : Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] IQueryHandler<QuestionResponse, GetQuestionsWithFiltersCommand> handler,
        [FromQuery] GetQuestionsDto request,
        CancellationToken cancellationToken)
    {
        var query = new GetQuestionsWithFiltersCommand(request);

        var result = await handler.Handle(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{questionId:guid}")]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid questionId,
        CancellationToken cancellationToken)
    {
        return this.Ok("Get question by id");
    }


    [HttpPut("{questionId:guid}")]
    public async Task<IActionResult> UpdateQuestion(
        [FromRoute] Guid questionId, [
        FromBody] UpdateQuestionsDto request,
        CancellationToken cancellationToken)
    {
        return this.Ok("Update question");
    }

    [HttpDelete("{questionId:guid}")]
    public async Task<IActionResult> DeleteQuestion(
        [FromRoute] Guid questionId,
        CancellationToken cancellationToken)
    {
        return this.Ok("Delete question");
    }

    [HttpPut("{questionId:guid}/solution")]
    public async Task<IActionResult> SelectSolution(
        [FromRoute] Guid questionId,
        [FromQuery] Guid answerId,
        CancellationToken cancellationToken)
    {
        return this.Ok("Select solution");
    }

    [HttpGet("{questionId:guid}/answers")]
    public async Task<IActionResult> AddAnswer(
        [FromServices] ICommandHandler<Guid, AddAnswerCommand> handler,
        [FromRoute] Guid questionId,
        [FromBody] AddAnswerDto request,
        CancellationToken cancellationToken)
    {
        var command = new AddAnswerCommand(questionId, request);
        var result = await handler.Handle(command, cancellationToken);
        return result.IsFailure ? result.Error.ToResponse() : Ok(result.Value);
    }

    [HttpGet("{questionId:guid}/comments")]
    public async Task<IActionResult> AddComment(
        [FromRoute] Guid questionId,
        [FromBody] AddCommentDto request,
        CancellationToken cancellationToken)
    {
        return this.Ok("Add comment");
    }
}

