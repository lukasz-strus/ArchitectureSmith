using Microsoft.Extensions.DependencyInjection;

namespace ArchitectureSmith.Authorization;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        return services;
    }
}