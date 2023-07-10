using E_CommerceAppAPI.Application.Repositories.Product;
using E_CommerceAppAPI.Persistence.Contexts;

namespace E_CommerceAppAPI.Persistence.Repositories.Product;

public class ProductWriteRepository:WriteRepository<Domain.Product>,IProductWriteRepository
{
    public ProductWriteRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}