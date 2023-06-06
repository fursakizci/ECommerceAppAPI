using E_CommerceAppAPI.Application.Repositories.Order;
using E_CommerceAppAPI.Persistence.Contexts;
using E_CommerceAppAPI.Persistence.Repositories;

namespace E_CommerceAppAPI.Persistence.Concretes.Order;

public class OrderReadRepository:ReadRepository<Domain.Order>,IOrderReadRepository
{
    public OrderReadRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}