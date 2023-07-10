using E_CommerceAppAPI.Application.Repositories.Product;
using MediatR;

namespace E_CommerceAppAPI.Application.Features.Commands.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest,GetAllProductQueryResponse>
{
    private readonly IProductReadRepository _productReadRepository;
    
    public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }
    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        var totalCount = _productReadRepository.GetAll(false).Count();
        var products = _productReadRepository.GetAll(false).Skip(request.Page * request.Size)
            .Take(request.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Orders,
                p.Stock,
                p.Price,
                p.CreateDate,
                p.UpdateDate
            }).ToList();
        return new()
        {
           Products = products,
           TotalCount = totalCount
        };
    }
}