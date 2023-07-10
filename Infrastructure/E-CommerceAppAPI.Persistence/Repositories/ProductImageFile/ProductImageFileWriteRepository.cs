using E_CommerceAppAPI.Application.Repositories.ProductImageFile;
using E_CommerceAppAPI.Persistence.Contexts;

namespace E_CommerceAppAPI.Persistence.Repositories.ProductImageFile;

public class ProductImageFileWriteRepository:WriteRepository<Domain.ProductImageFile>,IProductImageFileWriteRepository
{
    public ProductImageFileWriteRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}