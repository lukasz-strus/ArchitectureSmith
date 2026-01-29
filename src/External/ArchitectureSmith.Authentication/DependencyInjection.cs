using Microsoft.Extensions.DependencyInjection;

namespace ArchitectureSmith.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services)
    {
        return services;
    }
}