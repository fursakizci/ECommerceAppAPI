using E_CommerceAppAPI.Application.Repositories.ProductImageFile;
using E_CommerceAppAPI.Persistence.Contexts;

namespace E_CommerceAppAPI.Persistence.Repositories.ProductImageFile;

public class ProductImageFileReadRepository:ReadRepository<Domain.ProductImageFile>,IProductImageFileReadRepository
{
    public ProductImageFileReadRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}