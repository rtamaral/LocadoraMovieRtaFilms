using Microsoft.EntityFrameworkCore;
using MovieRental.Data.Models;

namespace MovieRental.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasKey(x => x.Id);

            modelBuilder.Entity<Rent>().HasKey(x => x.Id);
            modelBuilder.Entity<Rent>().HasMany(i => i.Movies).WithOne(i => i.Rent);
            modelBuilder.Entity<Rent>().HasOne(i => i.Customer);

            modelBuilder.Entity<ItemRent>().HasKey(x => x.Id);
            modelBuilder.Entity<ItemRent>().HasOne(x => x.Rent);
            modelBuilder.Entity<ItemRent>().HasOne(x => x.Movie);

            modelBuilder.Entity<Customer>().HasKey(x => x.Id);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
        }
    }
}