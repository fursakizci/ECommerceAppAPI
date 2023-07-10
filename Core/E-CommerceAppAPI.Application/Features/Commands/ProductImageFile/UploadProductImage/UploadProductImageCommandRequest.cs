using E_CommerceAppAPI.Application.Features.Commands.Product.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace E_CommerceAppAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;

public class UploadProductImageCommandRequest : IRequest<UploadProductImageCommandResponse>
{
    public string Id { get; set; }
    public IFormFileCollection Files { get; set; }
}