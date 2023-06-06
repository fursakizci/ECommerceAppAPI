using E_CommerceAppAPI.Domain;
using E_CommerceAppAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAppAPI.Persistence.Contexts;

public class ECommerceApiDbContext : DbContext
{
    public ECommerceApiDbContext(DbContextOptions options): base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    // It is a property that enables the capture of changes or newly added data made through entities.
    // It allows us to capture and obtain the data tracked in update operations.
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
            EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
            EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
            _ => DateTime.UtcNow
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToLower());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLower());
            }
        }
    }
}