using E_CommerceAppAPI.Application.Repositories.Product;
using MediatR;

namespace E_CommerceAppAPI.Application.Features.Commands.Product.CreateProduct;

public class CreateProductHandler:IRequestHandler<CreateProductCommandRequest,CreateProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;
    
    public CreateProductHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _productWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Stock = request.Stock,
            Price = request.Price
        });
        await _productWriteRepository.SaveAsync();
        return new();
    }
}