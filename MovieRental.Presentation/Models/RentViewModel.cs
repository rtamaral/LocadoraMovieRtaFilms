using MovieRental.Data.Models;
using System.Collections.Generic;

namespace MovieRental.Presentation.Models
{
    public class RentViewModel
    {
        public RentViewModel(IList<Movie> movies, Rent rent)
        {
            Movies = movies;
            Rent = rent;
        }

        public IList<Movie> Movies { get; set; }
        public Rent Rent { get; set; }
    }
}
