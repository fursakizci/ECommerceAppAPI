using E_CommerceAppAPI.Application.Abstractions.Storage;
using E_CommerceAppAPI.Application.Features.Commands.Product.UpdateProduct;
using E_CommerceAppAPI.Application.Repositories.Product;
using E_CommerceAppAPI.Application.Repositories.ProductImageFile;
using MediatR;

namespace E_CommerceAppAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;

public class UploadProductImageCommandHandler:IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
{
    private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
    private readonly IStorageService _storageService;
    private readonly IProductReadRepository _productReadRepository;
    
    public UploadProductImageCommandHandler(
        IProductImageFileWriteRepository productImageFileWriteRepository,
        IStorageService storageService,
        IProductReadRepository productReadRepository
        )
    {
        _productImageFileWriteRepository = productImageFileWriteRepository;
        _storageService = storageService;
        _productReadRepository = productReadRepository;
    }
    
    public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathOrContainerName)> result = 
            await _storageService.UploadAsync("photo-images", request.Files);

        Domain.Product product = await _productReadRepository.GetByIdAsync(request.Id);
        
        await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => 
            new Domain.ProductImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Domain.Product>() { product }
            }).ToList());


        await _productImageFileWriteRepository.SaveAsync();

        return new();
    }
}