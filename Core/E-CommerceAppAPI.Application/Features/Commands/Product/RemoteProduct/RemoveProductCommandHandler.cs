using E_CommerceAppAPI.Application.Repositories.Product;
using MediatR;

namespace E_CommerceAppAPI.Application.Features.Commands.Product.RemoteProduct;

public class RemoveProductCommandHandler:IRequestHandler<RemoveProductCommandRequest,RemoveProductCommandResponse>
{
    private readonly IProductWriteRepository _productWriteRepository;

    public RemoveProductCommandHandler(IProductWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }
    
    public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _productWriteRepository.RemoveAsync(request.Id);
        await _productWriteRepository.SaveAsync();
        return new();
    }
}