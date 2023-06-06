using E_CommerceAppAPI.Application.Abstractions;
using E_CommerceAppAPI.Domain;

namespace E_CommerceAppAPI.Persistence.Concretes;

public class ProductService:IProductService
{
    public List<Domain.Product> GetProducts()
        => new()
        {
            new() { Id = Guid.NewGuid(), Name = "Product1", Price = 100, Stock = 10 },
            new() { Id = Guid.NewGuid(), Name = "Product2", Price = 200, Stock = 20 },
            new() { Id = Guid.NewGuid(), Name = "Product3", Price = 300, Stock = 30 },
            new() { Id = Guid.NewGuid(), Name = "Product4", Price = 400, Stock = 40 },
            new() { Id = Guid.NewGuid(), Name = "Product5", Price = 500, Stock = 50 }
        };
}