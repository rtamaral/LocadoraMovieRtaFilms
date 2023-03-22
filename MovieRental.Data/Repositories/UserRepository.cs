using MovieRental.Data.Context;
using MovieRental.Data.Models;

namespace MovieRental.Data.Repositories
{
    public class UserRepository : BaseRepository<User> , IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
