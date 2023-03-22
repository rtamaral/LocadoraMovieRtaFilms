using Microsoft.AspNetCore.Mvc;
using MovieRental.Data.Repositories;
using MovieRental.Presentation.Models;

namespace MovieRental.Presentation.Controllers
{
    public class RentController : Controller
    {
        private readonly IRentService _rentService;
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

        public RentController(IRentService rentService, IMovieRepository movieRepository, IUserRepository userRepository)
        {
            _rentService = rentService;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var movies = _movieRepository.GetAll();
            var rent = _rentService.GetRent();
            ViewBag.UserName = _userRepository.GetById(1).Username;
            var viewModel = new RentViewModel(movies, rent);
            return View(viewModel);
        }

        public IActionResult AddMovie(int id)
        {
            _rentService.AddItem(id);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveMovie(int id)
        {
            _rentService.RemoveItem(id);
            return RedirectToAction("Index");
        }
    }
}
