using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceAPI.Persistence.Contexts;

public class ETicaretAPIDbContext : DbContext
{
    public ETicaretAPIDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) // Veri eklediğimizde veya güncellediğimizde çalışacak metod
    {
        
        //ChangeTracker : Entityler üzerinden yapılan değşikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir.
        //Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar
        
        var datas = ChangeTracker.Entries<BaseEntity>(); // Data'ları yakalıyoruz

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow, // State = Added , olanların CreateDate'ini düzenliyoruz
                EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow, // State = Modified , olanların UpdateDate'ini düzenliyoruz
            };
        }
        
        return await base.SaveChangesAsync(cancellationToken);
    }
    
}