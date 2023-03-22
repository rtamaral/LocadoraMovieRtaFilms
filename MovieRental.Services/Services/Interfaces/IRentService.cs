using MovieRental.Data.Models;

namespace MovieRental.Data.Repositories
{
    public interface IRentService
    {
        void AddItem(long id);
        public Rent GetRent();
        void RemoveItem(int id);
        void UpdateCustomer(long customerId);
    }
}