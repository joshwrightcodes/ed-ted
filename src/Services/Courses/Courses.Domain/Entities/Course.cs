using Ted.Shared.Domain.Entities;

namespace Ted.Services.Courses.Domain.Entities;

public class Course : AuditableEntity
{
    private const string DefaultTitle = "New Course";

    public Course()
    {
        Status = CourseStatus.Draft;
        Id = Guid.NewGuid();
        Title = DefaultTitle;
        Tags = new Dictionary<string, string>();
    }

    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public CourseStatus Status { get; private set; }

    public string? ExternalId { get; private set; }

    public Dictionary<string, string> Tags { get; private set; }

    public void Publish(string userId)
    {
        // TODO: Domain Event

        Status = CourseStatus.Published;
    }

    public void Unpublish(string userId)
    {
        // TODO: Domain Event

        Status = CourseStatus.Draft;
    }
}

public enum CourseStatus
{
    Draft = 0,
    NeedsReview = 1,
    Reviewed = 2,
    Scheduled = 3,
    Published = 4,
    Archived = 5,
}

public class Branding : AuditableEntity
{
    public Guid Id { get; private set; }

    public Uri LogoUrl { get; private set; }

    public Uri BackgroundImage { get; private set; }

    public string BackgroundColour { get; private set; }

    public Uri FontUrl { get; private set; }

    public string TextForegroundColour { get; private set; }

    public string TextBackgroundColour { get; private set; }

    public Uri PreviewImageUrl { get; private set; }

    public Uri CatalogueImageUrl { get; private set; }
}