namespace MovieRental.Data.Models
{
    public class Movie: BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
