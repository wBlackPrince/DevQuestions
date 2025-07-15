namespace DevQuestionsDomain.Reports;

public enum ReportStatus
{
    /// <summary>
    /// Статус открыт.
    /// </summary>
    OPEN,

    /// <summary>
    /// Статус в работе.
    /// </summary>
    IN_PROGRESS,

    /// <summary>
    /// Статус разрешен.
    /// </summary>
    RESOLVED,

    /// <summary>
    /// Статус отклонен.
    /// </summary>
    DISMISSED,
}