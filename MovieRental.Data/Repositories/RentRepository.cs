using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieRental.Data.Context;
using MovieRental.Data.Models;
using System;
using System.Linq;

namespace MovieRental.Data.Repositories
{
    public class RentRepository : BaseRepository<Rent>, IRentRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RentRepository(ApplicationContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override Rent GetById(long id)
        {
            return _dbSet
                .Include(x => x.Movies)
                .ThenInclude(i => i.Movie)
                .Include(p => p.Customer)
                .SingleOrDefault(x => x.Id == id);
        }

        public void AddItem(ItemRent itemRent)
        {
            _context.Set<ItemRent>().Add(itemRent);
            _context.SaveChanges();
        }

        public void RemoveItem(ItemRent itemRent)
        {
            _context.Set<ItemRent>().Remove(itemRent);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Rent rent, long customerId)
        {
            rent.CustomerId = customerId;
            rent.ExpirationDate = DateTime.Today.AddDays(rent.Movies.Count * 2);
            _context.SaveChanges();
        }
    }
}
