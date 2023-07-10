using E_CommerceAppAPI.Application.Features.Commands.Product.RemoteProduct;
using E_CommerceAppAPI.Application.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAppAPI.Application.Features.Commands.ProductImageFile.RemoveProductImage;

public class RemoveProductImageCommandHandler:IRequestHandler<RemoveProductImageCommandRequest,RemoveProductImageCommandResponse>
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public RemoveProductImageCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
            .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

        Domain.ProductImageFile productImageFile = product?.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

        if (productImageFile != null)
        { 
            product?.ProductImageFiles.Remove(productImageFile);  
        }
        
        await _productWriteRepository.SaveAsync();
        return new();
    }
}