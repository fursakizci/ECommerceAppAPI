using E_CommerceAppAPI.Application.Repositories.Order;
using E_CommerceAppAPI.Persistence.Contexts;
using E_CommerceAppAPI.Persistence.Repositories;

namespace E_CommerceAppAPI.Persistence.Concretes.Order;

public class OrderWriteRepository:WriteRepository<Domain.Order>,IOrderWriteRepository
{
    public OrderWriteRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}