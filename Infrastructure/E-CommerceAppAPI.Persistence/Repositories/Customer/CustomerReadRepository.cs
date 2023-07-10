using E_CommerceAppAPI.Application.Repositories.Customer;
using E_CommerceAppAPI.Persistence.Contexts;

namespace E_CommerceAppAPI.Persistence.Repositories.Customer;

public class CustomerReadRepository: ReadRepository<Domain.Customer> ,ICustomerReadRepository
{
    //We wrote to send a value to DbContext
    public CustomerReadRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}