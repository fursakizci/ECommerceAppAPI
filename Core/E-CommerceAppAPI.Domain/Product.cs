using System.ComponentModel.DataAnnotations;
using E_CommerceAppAPI.Domain.Common;

namespace E_CommerceAppAPI.Domain;

public class Product:BaseEntity
{
   
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<ProductImageFile> ProductImageFiles { get; set; }
}