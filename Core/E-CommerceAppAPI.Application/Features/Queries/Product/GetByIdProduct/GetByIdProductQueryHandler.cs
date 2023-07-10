using E_CommerceAppAPI.Application.Repositories.Product;
using MediatR;

namespace E_CommerceAppAPI.Application.Features.Queries.Product.GetByIdProductHandler;

public class GetByIdProductQueryHandler:IRequestHandler<GetByIdProductRequest,GetByIdProductResponse>
{
    private readonly IProductReadRepository _productReadRepository;

    public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }
    public async Task<GetByIdProductResponse> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
    {
        Domain.Product product = await _productReadRepository.GetByIdAsync(request.Id,false);
        return new()
        {
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}