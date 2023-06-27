using System.ComponentModel.DataAnnotations;

namespace E_CommerceAppAPI.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreateDate { get; set; }
    
    virtual public DateTime UpdateDate { get; set; }
}