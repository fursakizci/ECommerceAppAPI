using E_CommerceAppAPI.Application.Repositories;
using E_CommerceAppAPI.Domain.Common;
using E_CommerceAppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace E_CommerceAppAPI.Persistence.Repositories;

public class WriteRepository<T>:IWriteRepository<T> where T : BaseEntity
{
    readonly private ECommerceApiDbContext _context;

    public WriteRepository(ECommerceApiDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    
    public async Task<bool> AddAsync(T model)
    {
        try
        {
            var entityEntry = await Table.AddAsync(model);
            // we check if the model has been added or not 
            return entityEntry.State == EntityState.Added;
        }
        catch (Exception e)
        {
            // Handle the exception
            Console.WriteLine(e);
            throw; // Optional: Rethrow the exception
        }
        
        // try
        // {
        //     var entityEntry = await Table.AddAsync(model);
        //     //we check if the model has been added or not 
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e);
        //     throw;
        // }
        
        //return entityEntry.State == EntityState.Added;
        return true;
    }

    public async Task<bool> AddRangeAsync(List<T> model)
    {
        try
        {
            await Table.AddRangeAsync(model);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
     
        return true;
    }

    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool RemoveRange(List<T> model)
    {
        Table.RemoveRange(model);
        return true;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        T model = await Table.FirstOrDefaultAsync(i => i.Id == Guid.Parse(id));
        return Remove(model);
    }

    public bool Update(T model)
    {
        EntityEntry<T> entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public Task<int> SaveAsync()
        => _context.SaveChangesAsync();
}