using MovieRental.Data.Models;

namespace MovieRental.Data.Repositories
{
    public interface IRentRepository : IBaseRepository<Rent>
    {
        void AddItem(ItemRent itemRent);
        void RemoveItem(ItemRent id);
        void UpdateCustomer(Rent rent, long customerId);
    }
}