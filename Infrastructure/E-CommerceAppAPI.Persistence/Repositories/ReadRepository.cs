using System.Linq.Expressions;
using E_CommerceAppAPI.Application.Repositories;
using E_CommerceAppAPI.Domain.Common;
using E_CommerceAppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAppAPI.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly ECommerceApiDbContext _context;

    public ReadRepository(ECommerceApiDbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();
    
    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        
        //No-tracking queries are useful when the results are used in a read-only scenario. 
        if (!tracking)
            query = query.AsNoTracking();

        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method,bool tracking = true)
    {
        var query = Table.Where(method);
        
        if (!tracking)
            query = query.AsNoTracking();
        
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method,bool tracking = true)
    {
        var query = Table.AsQueryable();

        if (!tracking)
            query = Table.AsQueryable();

        return await query.FirstOrDefaultAsync(method);

    }

    public async Task<T> GetByIdAsync(string id,bool tracking = true)
    {
        //return await Table.FirstOrDefaultAsync(i=>i.Id == Guid.Parse(id));
        var query = Table.AsQueryable();
        if (!tracking)
            query = Table.AsNoTracking();
        
        return await query.FirstOrDefaultAsync(i=>i.Id == Guid.Parse(id));
    }
}