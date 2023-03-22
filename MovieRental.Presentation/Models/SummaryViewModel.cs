using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRental.Data.Models;
using System.Collections.Generic;


namespace MovieRental.Presentation.Models
{
    public class SummaryViewModel
    {
        public SummaryViewModel(IList<SelectListItem> customers, Rent rent)
        {
            Customers = customers;
            Rent = rent;
        }

        public IList<SelectListItem> Customers { get; set; }
        public long CustomerId { get; set; }
        public Rent Rent { get; set; }
    }
}
