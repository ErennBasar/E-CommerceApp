using ECommerceAPI.Application.Repositories.Customer;
using ECommerceAPI.Persistence.Contexts;

namespace ECommerceAPI.Persistence.Repositories.Customer;

public class CustomerWriteRepository : WriteRepositor<Domain.Entities.Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(ETicaretAPIDbContext context) : base(context)
    {
    }
}