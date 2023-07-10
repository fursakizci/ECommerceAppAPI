using E_CommerceAppAPI.Application.Repositories.Order;
using E_CommerceAppAPI.Persistence.Contexts;

namespace E_CommerceAppAPI.Persistence.Repositories.Order;

public class OrderWriteRepository:WriteRepository<Domain.Order>,IOrderWriteRepository
{
    public OrderWriteRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}