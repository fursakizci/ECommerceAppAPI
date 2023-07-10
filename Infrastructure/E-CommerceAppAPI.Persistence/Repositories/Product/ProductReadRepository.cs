using E_CommerceAppAPI.Application.Repositories.Product;
using E_CommerceAppAPI.Persistence.Contexts;

namespace E_CommerceAppAPI.Persistence.Repositories.Product;

public class ProductReadRepository:ReadRepository<Domain.Product>,IProductReadRepository
{
    public ProductReadRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}