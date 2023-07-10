using MediatR;

namespace E_CommerceAppAPI.Application.Features.Queries.ProductImageFile.GetProductImages;

public class GetProductImagesQueryRequest : IRequest<List<GetProductImagesQueryResponse>>
{
    public string Id { get; set; }
}