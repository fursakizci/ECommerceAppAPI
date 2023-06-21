using System.Net;
using E_CommerceAppAPI.Application.Abstractions;
using E_CommerceAppAPI.Application.Repositories.Customer;
using E_CommerceAppAPI.Application.Repositories.Order;
using E_CommerceAppAPI.Application.Repositories.Product;
using E_CommerceAppAPI.Application.RequestParameters;
using E_CommerceAppAPI.Application.Services;
using E_CommerceAppAPI.Application.ViewModels;
using E_CommerceAppAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAppAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    //private readonly IProductService _productService;
    readonly private IProductReadRepository _productReadRepository;
    readonly private IProductWriteRepository _productWriteRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IFileService _fileService;

    
    
    public ProductController(
        //IProductService productService,
        IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository,
        IWebHostEnvironment webHostEnvironment,
        IFileService fileService
        )
    {
        //_productService = productService;
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _webHostEnvironment = webHostEnvironment;
        _fileService = fileService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]Pagination pagination)
    {
        var totalCount = _productReadRepository.GetAll(false).Count();
        var products = _productReadRepository.GetAll(false).Select(p => new
        {
            p.Id,
            p.Name,
            p.Orders,
            p.Stock,
            p.Price,
            p.CreateDate,
            p.UpdateDate
        }).Skip(pagination.Page * pagination.Size).Take(pagination.Size);

        return Ok(new
        {
            totalCount,
            products
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _productReadRepository.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(VM_Create_Product model)
    {
        await _productWriteRepository.AddAsync(new()
        {
            Name = model.Name,
            Stock = model.Stock,
            Price = model.Price
        });
        await _productWriteRepository.SaveAsync();
        return StatusCode((int)HttpStatusCode.Created); 
    }

    [HttpPut]
    public async Task<IActionResult> Put(VM_Update_Product model)
    {
        Product product = await _productReadRepository.GetByIdAsync(model.id);
        product.Name = model.Name;
        product.Stock = model.Stock;
        product.Price = model.Price;
        await _productWriteRepository.SaveAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _productWriteRepository.RemoveAsync(id);
        await _productWriteRepository.SaveAsync();
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Upload()
    {
        // //wwwroot/resource/product-images
        // string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath,"resource/product-images");
        //
        // if (!Directory.Exists(uploadPath))
        //     Directory.CreateDirectory(uploadPath);
        //
        // Random r = new();
        // foreach (IFormFile file in Request.Form.Files)
        // {
        //     string fullPath = Path.Combine(uploadPath, file.Name);
        //
        //     using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None,
        //         1024 * 1024, useAsync: false);
        //
        //     await file.CopyToAsync(fileStream);
        //     await fileStream.FlushAsync();
        // }
        await  _fileService.UploadAsync("resource/product-images",Request.Form.Files);
 
        return Ok();
    }



}
