using System.Net;
using E_CommerceAppAPI.Application.Abstractions;
using E_CommerceAppAPI.Application.Repositories.Customer;
using E_CommerceAppAPI.Application.Repositories.Order;
using E_CommerceAppAPI.Application.Repositories.Product;
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

    
    
    public ProductController(
        //IProductService productService,
        IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository
        )
    {
        //_productService = productService;
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(_productReadRepository.GetAll());
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



}
