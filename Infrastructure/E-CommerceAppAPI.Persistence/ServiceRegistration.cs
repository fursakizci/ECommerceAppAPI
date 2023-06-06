using E_CommerceAppAPI.Application.Abstractions;
using E_CommerceAppAPI.Application.Repositories.Customer;
using E_CommerceAppAPI.Application.Repositories.Order;
using E_CommerceAppAPI.Application.Repositories.Product;
using E_CommerceAppAPI.Persistence.Concretes;
using E_CommerceAppAPI.Persistence.Concretes.Customer;
using E_CommerceAppAPI.Persistence.Concretes.Order;
using E_CommerceAppAPI.Persistence.Concretes.Product;
using E_CommerceAppAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAppAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ECommerceApiDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepositoru>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
    }
}