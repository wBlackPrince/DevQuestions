using Microsoft.EntityFrameworkCore;
using Tags.Domain;

namespace Tags.Database;

public class TagsDbContext: DbContext
{
    public DbSet<Tag> Tags { get; set; }

    public IQueryable<Tag> ReadTags => Tags.AsNoTracking().AsQueryable();
}