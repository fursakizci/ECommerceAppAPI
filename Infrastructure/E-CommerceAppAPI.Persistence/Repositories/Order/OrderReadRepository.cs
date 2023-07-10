using E_CommerceAppAPI.Application.Repositories.Order;
using E_CommerceAppAPI.Persistence.Contexts;

namespace E_CommerceAppAPI.Persistence.Repositories.Order;

public class OrderReadRepository:ReadRepository<Domain.Order>,IOrderReadRepository
{
    public OrderReadRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}