using DevQuestionsDomain.Tags;

namespace DevQuestions.Application.Tags;

public interface ITagsReadDbContext{
    IQueryable<Tag> ReadTags { get; }
}