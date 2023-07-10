using MediatR;
using E_CommerceAppAPI.Application.RequestParameters;
namespace E_CommerceAppAPI.Application.Features.Commands.GetAllProduct;

public class GetAllProductQueryRequest:IRequest<GetAllProductQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}