using E_CommerceAppAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAppAPI.Application.Repositories;

public interface IRepository<T> where T : BaseEntity 
{
    DbSet<T>Table { get; }
}