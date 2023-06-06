using System.ComponentModel.DataAnnotations;

namespace E_CommerceAppAPI.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreateDate { get; set; }
    
    public DateTime UpdateDate { get; set; }
}