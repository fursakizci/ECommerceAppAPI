using E_CommerceAppAPI.Application.Services;
using E_CommerceAppAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAppAPI.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IFileService, FileServices>();
    }
}