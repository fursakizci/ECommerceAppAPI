
using E_CommerceAppAPI.Application.Abstractions.Storage;
using E_CommerceAppAPI.Infrastructure.Services;
using E_CommerceAppAPI.Infrastructure.Services.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAppAPI.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IStorageService, StorageService>();
    }

    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }
}