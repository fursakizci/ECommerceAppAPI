using E_CommerceAppAPI.Application.Features.Commands.Product.RemoteProduct;
using MediatR;

namespace E_CommerceAppAPI.Application.Features.Commands.ProductImageFile.RemoveProductImage;

public class RemoveProductImageCommandRequest : IRequest<RemoveProductImageCommandResponse>
{
    public string Id { get; set; }
    public string? ImageId { get; set; }
}