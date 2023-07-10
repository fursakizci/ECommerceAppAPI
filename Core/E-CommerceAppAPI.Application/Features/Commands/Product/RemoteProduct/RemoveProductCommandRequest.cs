using MediatR;

namespace E_CommerceAppAPI.Application.Features.Commands.Product.RemoteProduct;

public class RemoveProductCommandRequest : IRequest<RemoveProductCommandResponse>
{
    public string Id { get; set; }
}