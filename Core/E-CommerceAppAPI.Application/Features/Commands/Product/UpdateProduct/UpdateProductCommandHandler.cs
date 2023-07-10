using E_CommerceAppAPI.Application.Repositories.Product;
using MediatR;

namespace E_CommerceAppAPI.Application.Features.Commands.Product.UpdateProduct;

public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommandRequest,UpdateProductCommandResponse>
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public UpdateProductCommandHandler(
        IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }
    
    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Product product = await _productReadRepository.GetByIdAsync(request.Id);
        product.Name = request.Name;
        product.Stock = request.Stock;
        product.Price = request.Price;
        await _productWriteRepository.SaveAsync();
        return new();
    }
}