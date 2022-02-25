namespace Ted.Shared.Application;

public interface ICurrentUserService
{
    string? UserId { get; }
}