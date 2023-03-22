using Microsoft.EntityFrameworkCore;
using MovieRental.Data.Context;
using MovieRental.Data.Models;
using MovieRtaFilms.Data.InitialData;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Data.InitialData
{
    public class InitialData : IInitialData
    {

        private readonly ApplicationContext _context;

        public InitialData(ApplicationContext context)
        {
            _context = context;
        }

        public void StartDb()
        {
            _context.Database.Migrate();

            var user = new User { Username = "Administrador", Password = "123" };

            List<Movie> movies = new List<Movie>{
                   new Movie{Code = "Movie001", Name="Star Wars", Price = 7},
                   new Movie{Code = "Movie002", Name="Harry Potter", Price = 5},
                   new Movie{Code = "Movie003", Name="Tenacious D", Price = 2},
                   new Movie{Code = "Movie004", Name="O Hobbit", Price = 5},
                   new Movie{Code = "Movie005", Name="Pé Pequeno", Price = 2.50m},
                   new Movie{Code = "Movie006", Name="Inception", Price = 1.90m},
                   new Movie{Code = "Movie007", Name="O Senhor dos Anéis", Price = 4},
                   new Movie{Code = "Movie008", Name="Annabelle", Price = 6},
                   new Movie{Code = "Movie009", Name="Gente Grande", Price = 2}

            };

            List<Customer> customers = new List<Customer>{
                   new Customer{ FullName = "Maria Santos", Email = "mariasantos@email.com.br"},
                   new Customer{ FullName = "João da Silva", Email = "joaosilva@email.com.br"},
                   new Customer{ FullName = "Pedro Almeida", Email = "pedroalmeida@email.com.br"},
                   new Customer{ FullName = "Felipe Leonardo Sousa", Email = "flsousa@email.com.br"},
            };


            foreach (var movie in movies)
            {
                if (!_context.Set<Movie>().Where(p => p.Code == movie.Code).Any())
                {
                    _context.Set<Movie>().Add(movie);
                }
            }

            foreach (var customer in customers)
            {
                if (!_context.Set<Customer>().Where(p => p.FullName == customer.FullName).Any())
                {
                    _context.Set<Customer>().Add(customer);
                }
            }

            if (!_context.Set<User>().Any())
            {
                _context.Set<User>().Add(user);
            }
            _context.SaveChanges();
        }
    }
}
