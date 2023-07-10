using MediatR;

namespace E_CommerceAppAPI.Application.Features.Queries.Product.GetByIdProductHandler;

public class GetByIdProductRequest : IRequest<GetByIdProductResponse>
{
    public string Id { get; set; }
}