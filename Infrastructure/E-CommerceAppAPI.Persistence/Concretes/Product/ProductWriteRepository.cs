using E_CommerceAppAPI.Application.Repositories.Product;
using E_CommerceAppAPI.Persistence.Contexts;
using E_CommerceAppAPI.Persistence.Repositories;

namespace E_CommerceAppAPI.Persistence.Concretes.Product;

public class ProductWriteRepository:WriteRepository<Domain.Product>,IProductWriteRepository
{
    public ProductWriteRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}