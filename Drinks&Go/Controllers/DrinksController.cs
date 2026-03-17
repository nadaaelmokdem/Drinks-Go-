using Drinks_Go.Interfaces;
using Drinks_Go.Models;
using Drinks_Go.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Drinks_Go.Controllers
{
    public class DrinksController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinksRepository _drinksRepository;

        public DrinksController(ICategoryRepository categoryRepository, IDrinksRepository drinksRepository)
        {
            _categoryRepository = categoryRepository;
            _drinksRepository = drinksRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinksRepository.Drinks.OrderBy(d => d.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                drinks = _drinksRepository.Drinks
                    .Where(d => d.Category.CategoryName.Equals(category, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(d => d.DrinkId);

                currentCategory = _categoryRepository.Categories
                    .FirstOrDefault(c => c.CategoryName.Equals(category, StringComparison.OrdinalIgnoreCase))?.CategoryName
                    ?? "Unknown";
            }

            var drinksListViewModel = new DrinksListViewModel
            {
                Drinks = drinks.ToList(),   
                CurrentCategory = currentCategory
            };

            return View(drinksListViewModel);
        }

    }
}
