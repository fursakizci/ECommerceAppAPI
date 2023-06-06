using E_CommerceAppAPI.Domain.Common;

namespace E_CommerceAppAPI.Domain;

public class Order:BaseEntity
{
    public Guid CustomerId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public ICollection<Product> Products { get; set; }
    public Customer Customer { get; set; }
}