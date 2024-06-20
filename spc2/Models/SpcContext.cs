using Microsoft.EntityFrameworkCore;

namespace Models;

public class SpcContext : DbContext
{
    public SpcContext(DbContextOptions<SpcContext> options)
        : base(options)
    {
    }

    public DbSet<Polygon> Polygons { get; set; } = null!;
}