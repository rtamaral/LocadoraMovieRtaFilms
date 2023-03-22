using MovieRental.Data.Context;
using MovieRental.Data.Models;

namespace MovieRental.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer> , ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
