namespace MovieRental.Data.Models
{
    public class ItemRent: BaseModel
    {
        public Movie Movie { get; set; }
        public Rent Rent { get; set; }
    }
}