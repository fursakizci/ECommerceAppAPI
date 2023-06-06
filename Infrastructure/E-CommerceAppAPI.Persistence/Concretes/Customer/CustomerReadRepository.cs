using E_CommerceAppAPI.Application.Repositories;
using E_CommerceAppAPI.Application.Repositories.Customer;
using E_CommerceAppAPI.Persistence.Contexts;
using E_CommerceAppAPI.Persistence.Repositories;

namespace E_CommerceAppAPI.Persistence.Concretes.Customer;

public class CustomerReadRepository: ReadRepository<Domain.Customer> ,ICustomerReadRepository
{
    //We wrote to send a value to DbContext
    public CustomerReadRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}