namespace E_CommerceAppAPI.Domain;

public class ProductImageFile:File
{
    public ICollection<Product> Products { get; set; }
}