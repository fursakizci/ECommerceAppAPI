using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceAppAPI.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddMediatR(typeof(ServiceRegistration));
    }
}