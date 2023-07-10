using E_CommerceAppAPI.Application.Repositories;
using E_CommerceAppAPI.Application.Repositories.Customer;
using E_CommerceAppAPI.Application.Repositories.InvoiceFile;
using E_CommerceAppAPI.Application.Repositories.Order;
using E_CommerceAppAPI.Application.Repositories.Product;
using E_CommerceAppAPI.Application.Repositories.ProductImageFile;
using E_CommerceAppAPI.Persistence.Contexts;
using E_CommerceAppAPI.Persistence.Repositories.Customer;
using E_CommerceAppAPI.Persistence.Repositories.File;
using E_CommerceAppAPI.Persistence.Repositories.InvoiceFile;
using E_CommerceAppAPI.Persistence.Repositories.Order;
using E_CommerceAppAPI.Persistence.Repositories.Product;
using E_CommerceAppAPI.Persistence.Repositories.ProductImageFile;
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
        services.AddScoped<IFileReadRepository, FileReadRepository>();
        services.AddScoped<IFileWriteRepository, FileWriteRepository>();
        services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
        services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
        services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
        services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
    }
}