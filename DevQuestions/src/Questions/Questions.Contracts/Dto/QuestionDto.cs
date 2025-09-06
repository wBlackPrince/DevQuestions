namespace Questions.Contracts.Dto;

public record QuestionDto(
    Guid Id,
    string Title,
    string Text,
    Guid UserId,
    string? ScreenshotUrl,
    Guid? SolutionId,
    IEnumerable<string> Tags,
    string Status
);