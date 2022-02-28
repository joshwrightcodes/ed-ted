using Microsoft.Extensions.DependencyInjection;

namespace Ted.Services.Enrolment.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        return services;
    }
}