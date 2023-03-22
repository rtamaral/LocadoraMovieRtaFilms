using MovieRental.Data.Context;
using MovieRental.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Data.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
