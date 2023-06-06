using E_CommerceAppAPI.Application.Repositories.Customer;
using E_CommerceAppAPI.Persistence.Contexts;
using E_CommerceAppAPI.Persistence.Repositories;

namespace E_CommerceAppAPI.Persistence.Concretes.Customer;

public class CustomerWriteRepositoru:WriteRepository<Domain.Customer>,ICustomerWriteRepository
{
    public CustomerWriteRepositoru(ECommerceApiDbContext context) : base(context)
    {
    }
}