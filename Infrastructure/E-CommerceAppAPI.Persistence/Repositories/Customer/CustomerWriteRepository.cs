using E_CommerceAppAPI.Application.Repositories.Customer;
using E_CommerceAppAPI.Persistence.Contexts;

namespace E_CommerceAppAPI.Persistence.Repositories.Customer;

public class CustomerWriteRepositoru:WriteRepository<Domain.Customer>,ICustomerWriteRepository
{
    public CustomerWriteRepositoru(ECommerceApiDbContext context) : base(context)
    {
    }
}