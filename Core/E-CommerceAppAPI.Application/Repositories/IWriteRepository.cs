using E_CommerceAppAPI.Domain.Common;

namespace E_CommerceAppAPI.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
     Task<bool> AddAsync(T model);
     Task<bool> AddRangeAsync(List<T> model);
     bool Remove(T model);
     bool RemoveRange(List<T> model);
     Task<bool> RemoveAsync(string id);
     bool Update(T model);
     Task<int> SaveAsync();
}