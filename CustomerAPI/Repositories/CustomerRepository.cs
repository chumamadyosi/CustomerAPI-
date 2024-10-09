using CustomerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context) : base(context) => _context = context;
    }
}
