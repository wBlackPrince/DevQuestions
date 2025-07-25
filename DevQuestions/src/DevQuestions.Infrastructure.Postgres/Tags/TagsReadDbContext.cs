using DevQuestions.Application.Tags;
using DevQuestionsDomain.Tags;
using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Infrastructure.Postgres.Tags;

public class TagsReadDbContext: DbContext, ITagsReadDbContext
{
    public DbSet<Tag> Tags { get; set; }

    public IQueryable<Tag> ReadTags => Tags.AsNoTracking().AsQueryable();
}