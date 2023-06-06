using System.ComponentModel.DataAnnotations;
using E_CommerceAppAPI.Domain.Common;

namespace E_CommerceAppAPI.Domain;

public class Customer:BaseEntity
{
    
    public string Name { get; set; }
   
    public ICollection<Order> Orders { get; set; }
}