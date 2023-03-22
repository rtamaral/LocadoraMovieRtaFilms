
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRental.Data.Repositories;
using MovieRental.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Presentation.Controllers
{
    public class SummaryController : Controller
    {
        private readonly IRentService _rentService;
        private readonly ICustomerRepository _customerRepository;

        public SummaryController(IRentService rentService, ICustomerRepository customerRepository)
        {
            _rentService = rentService;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {

            var customers = new List<SelectListItem>()
                {
                    new SelectListItem("Selecione o cliente", "0")
                };

            customers.AddRange(_customerRepository.GetAll().Select(x => new SelectListItem(x.FullName, x.Id.ToString())));
            var rent = _rentService.GetRent();

            var viewModel = new SummaryViewModel(customers, rent);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetCustomerData(long id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
                return Json(new { Success = false });

            return Json(new
            {
                Success = true,
                customer.Id,
                customer.Email,
            });
        }

        [HttpPost]
        public IActionResult SaveRent(long customerId)
        {
            try
            {
                _rentService.UpdateCustomer(customerId);
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Rent");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        public IActionResult RemoveMovie(int id)
        {
            _rentService.RemoveItem(id);
            return RedirectToAction("Index");
        }
    }
}
