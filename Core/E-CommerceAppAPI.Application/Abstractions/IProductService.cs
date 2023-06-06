using E_CommerceAppAPI.Domain;

namespace E_CommerceAppAPI.Application.Abstractions;

public interface IProductService
{
    List<Product> GetProducts();
}