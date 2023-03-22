using Microsoft.EntityFrameworkCore;
using MovieRental.Data.Context;
using MovieRental.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Data.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public T Create(T entity)
        {
            var newEntity = _dbSet.Add(entity);
            _context.SaveChanges();
            return newEntity.Entity;
        }

        public T Update(T entity)
        {
            var updatedEntity = _dbSet.Update(entity);
            _context.SaveChanges();
            return updatedEntity.Entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
