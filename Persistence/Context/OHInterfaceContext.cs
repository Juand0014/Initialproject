using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class OHInterfaceContext : DbContext
{
    public OHInterfaceContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
