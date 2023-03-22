using MovieRental.Data.Models;
using System.Collections.Generic;

namespace MovieRental.Data.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        T Create(T entity);
        void Delete(T entity);
        IList<T> GetAll();
        T GetById(long id);
        T Update(T entity);
    }
}