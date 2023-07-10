using System.ComponentModel.DataAnnotations.Schema;
using E_CommerceAppAPI.Domain.Common;

namespace E_CommerceAppAPI.Domain;

public class File:BaseEntity
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Storage { get; set; }

    //when entity is mapped to the database the operation ensures that this property is not mapped 
    [NotMapped]
    public override DateTime UpdateDate { get => base.UpdateDate; set => base.UpdateDate = value; }
}