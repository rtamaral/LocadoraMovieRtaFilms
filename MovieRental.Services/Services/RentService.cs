using Microsoft.AspNetCore.Http;
using MovieRental.Data.Models;
using System;
using System.Linq;

namespace MovieRental.Data.Repositories
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RentService(IRentRepository rentRepository, IMovieRepository movieRepository, IHttpContextAccessor httpContextAccessor)
        {
            _rentRepository = rentRepository;
            _movieRepository = movieRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public Rent GetById(long id)
        {
            return _rentRepository.GetById(id);
        }

        public void AddItem(long id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
                throw new ArgumentException("Filme não encontrado");

            var rent = GetRent();

            var itemRent = rent.Movies.FirstOrDefault(x => x.Movie.Id == id);
            if (itemRent != null)
                return;

            itemRent = new ItemRent()
            {
                Movie = movie,
                Rent = rent
            };

            _rentRepository.AddItem(itemRent);
        }

        public Rent GetRent()
        {
            var rentId = GetRentId();
            var rent = _rentRepository.GetById(rentId ?? 0);

            if (rent != null)
                return rent;

            rent = new Rent();
            _rentRepository.Create(rent);
            SetRentId(rent.Id);

            return rent;
        }

        public void RemoveItem(int id)
        {
            var rent = GetRent();
            var itemRent = rent.Movies.FirstOrDefault(x => x.Movie.Id == id);
            _rentRepository.RemoveItem(itemRent);
        }

        public void UpdateCustomer(long customerId)
        {
            var rent = GetById(GetRentId() ?? 0);
            if (rent == null)
                throw new Exception("Rent not found");

            _rentRepository.UpdateCustomer(rent, customerId);
        }

        private long? GetRentId()
        {
            var rentId = _httpContextAccessor.HttpContext.Session.GetString("rentId");
            if (rentId == null)
                return null;

            return long.Parse(rentId);
        }

        private void SetRentId(long rentId)
        {
            _httpContextAccessor.HttpContext.Session.SetString("rentId", rentId.ToString());
        }
    }
}
