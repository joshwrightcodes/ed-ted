using Ted.Services.Courses.Application;

namespace Ted.Services.Courses.Infrastructure.Persistence;

public class ApplicationDbContext : IApplicationDbContext
{
    public ApplicationDbContext()
    {
            
    }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}