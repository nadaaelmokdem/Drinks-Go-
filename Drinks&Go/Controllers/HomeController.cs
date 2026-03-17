using System.Diagnostics;
using Drinks_Go.Interfaces;
using Drinks_Go.Models;
using Microsoft.AspNetCore.Mvc;

namespace Drinks_Go.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinksRepository drinksRepository;
        private readonly ICategoryRepository categoryRepository;
        public HomeController(IDrinksRepository drinksRepository, ICategoryRepository categoryRepository)
        {
            this.drinksRepository = drinksRepository;
            this.categoryRepository = categoryRepository;
        }
        public ViewResult Index()
        {
            var homeVM = new HomeViewModel
            {
                PreferredDrinks = drinksRepository.PreferredDrinks
            };
            return View(homeVM);
        }
    }
}
