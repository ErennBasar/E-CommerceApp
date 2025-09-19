using ECommerceAPI.Application.Repositories.Product;
using ECommerceAPI.Persistence.Contexts;

namespace ECommerceAPI.Persistence.Repositories.Product;

public class ProductWriteRepository : WriteRepositor<Domain.Entities.Product>, IProductWriteRepository
{
    public ProductWriteRepository(ETicaretAPIDbContext context) : base(context)
    {
    }
}