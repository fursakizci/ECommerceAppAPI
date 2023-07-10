using System.Drawing;
using System.Net;
using E_CommerceAppAPI.Application.Abstractions.Storage;
using E_CommerceAppAPI.Application.Repositories;
using E_CommerceAppAPI.Application.Repositories.Customer;
using E_CommerceAppAPI.Application.Repositories.InvoiceFile;
using E_CommerceAppAPI.Application.Repositories.Order;
using E_CommerceAppAPI.Application.Repositories.Product;
using E_CommerceAppAPI.Application.Repositories.ProductImageFile;
using E_CommerceAppAPI.Application.RequestParameters;
using E_CommerceAppAPI.Application.Features.Commands.GetAllProduct;
using E_CommerceAppAPI.Application.ViewModels;
using E_CommerceAppAPI.Domain;
using E_CommerceAppAPI.Persistence.Repositories.ProductImageFile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using E_CommerceAppAPI.Application.Features.Commands.Product.CreateProduct;
using E_CommerceAppAPI.Application.Features.Commands.Product.RemoteProduct;
using E_CommerceAppAPI.Application.Features.Commands.Product.UpdateProduct;
using E_CommerceAppAPI.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using E_CommerceAppAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;
using E_CommerceAppAPI.Application.Features.Queries.Product.GetByIdProductHandler;
using E_CommerceAppAPI.Application.Features.Queries.ProductImageFile.GetProductImages;
using MediatR;


namespace E_CommerceAppAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IMediator _mediator;
    
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]GetAllProductQueryRequest getAllProductQueryRequest)
    {
       GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
       return Ok(response);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdProductRequest getByIdProductRequest)
    {
        GetByIdProductResponse response = await _mediator.Send(getByIdProductRequest);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
    {
        CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
        return StatusCode((int)HttpStatusCode.Created); 
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody]UpdateProductCommandRequest updateProductCommandRequest)
    {
        UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
        return Ok();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
    {
        RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Upload([FromQuery]UploadProductImageCommandRequest uploadProductImageCommandRequest)
    {
        uploadProductImageCommandRequest.Files = Request.Form.Files;
        UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);
        return Ok();
    }

    [HttpGet("[action]/{id}")] 
    public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest getProductImagesQueryRequest)
    {
        List<GetProductImagesQueryResponse> response = await _mediator.Send(getProductImagesQueryRequest);
        return Ok(response);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest, [FromQuery] string imageId)
    {
        removeProductImageCommandRequest.ImageId = imageId;
        RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);
        return Ok();
    } 

}

