using DevQuestion.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DevQuestions.Presenters;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateQuestionDto request, 
        CancellationToken cancellationToken)
    {
        return this.Ok("Question created");
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] GetQuestionsDto request,
        CancellationToken cancellationToken)
    {
        return this.Ok("Get questions with query parameters");
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
    public async Task<IActionResult> SelectSolution (
        [FromRoute] Guid questionId, 
        [FromQuery] Guid answerId, 
        CancellationToken cancellationToken)
    {
        return this.Ok("Select solution");
    }

    [HttpGet("{questionId:guid}/answers")]
    public async Task<IActionResult> AddAnswer(
        [FromRoute] Guid questionId, 
        [FromBody] AddAnswerDto request, 
        CancellationToken cancellationToken)
    {
        return this.Ok("Add answer");
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

