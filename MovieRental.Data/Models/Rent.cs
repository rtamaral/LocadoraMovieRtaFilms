using System;
using System.Collections.Generic;

namespace MovieRental.Data.Models
{
    public class Rent: BaseModel
    {
        public long? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ItemRent> Movies { get; set; }
        public DateTime ExpirationDate { get; set; }    
    }
}
