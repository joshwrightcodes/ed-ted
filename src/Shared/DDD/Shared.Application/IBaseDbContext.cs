namespace Ted.Shared.Application;

public interface IBaseDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}