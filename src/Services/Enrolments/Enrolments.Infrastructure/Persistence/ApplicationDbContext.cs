using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Ted.Shared.Application;
using Ted.Shared.Application.DomainEvents;
using Ted.Shared.Domain.Entities;
using Ted.Shared.Domain.Events;

namespace Ted.Services.Enrolment.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeOffset _dateTimeOffset;
    private readonly IDomainEventService _domainEventService;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IDomainEventService domainEventService,
        ICurrentUserService currentUserService,
        IDateTimeOffset dateTimeOffset)
        : base(options)
    {
        ArgumentNullException.ThrowIfNull(domainEventService);
        ArgumentNullException.ThrowIfNull(currentUserService);
        ArgumentNullException.ThrowIfNull(dateTimeOffset);

        _domainEventService = domainEventService;
        _currentUserService = currentUserService;
        _dateTimeOffset = dateTimeOffset;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.CreatedOn = _dateTimeOffset.UtcNow;
                    entry.Entity.ModifiedBy = entry.Entity.CreatedBy;
                    entry.Entity.ModifiedOn = entry.Entity.CreatedOn;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifiedBy = _currentUserService.UserId;
                    entry.Entity.ModifiedOn = _dateTimeOffset.UtcNow;
                    break;
            }

        var events = ChangeTracker.Entries<IHasDomainEvents>()
            .Select(x => x.Entity.DomainEvents)
            .SelectMany(x => x)
            .Where(domainEvent => !domainEvent.IsPublished)
            .ToArray();

        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents(events);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    private async Task DispatchEvents(DomainEvent[] events)
    {
        ArgumentNullException.ThrowIfNull(events);

        foreach (var @event in events)
        {
            @event.IsPublished = true;
            await _domainEventService.Publish(@event);
        }
    }
}