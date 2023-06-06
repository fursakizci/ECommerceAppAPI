using E_CommerceAppAPI.Application.Repositories.Product;
using E_CommerceAppAPI.Persistence.Contexts;
using E_CommerceAppAPI.Persistence.Repositories;

namespace E_CommerceAppAPI.Persistence.Concretes.Product;

public class ProductReadRepository:ReadRepository<Domain.Product>,IProductReadRepository
{
    public ProductReadRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}