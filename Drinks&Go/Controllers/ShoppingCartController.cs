using Microsoft.AspNetCore.Mvc;
using Drinks_Go.Models;

namespace Drinks_Go.Controllers
{
    public class ShoppingCartController : Controller
    {
       private readonly Drinks_Go.Interfaces.IDrinksRepository drinksRepository;
        private readonly Drinks_Go.Models.ShoppingCart shoppingCart;
        public ShoppingCartController(Drinks_Go.Interfaces.IDrinksRepository drinksRepository, Drinks_Go.Models.ShoppingCart shoppingCart)
        {
            this.drinksRepository = drinksRepository;
            this.shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetCartTotal() // Fixed method name
            };
            return View(sCVM);
        }
        public RedirectToActionResult AddToShoppingCart(int drinkId)
        {
            var selectedDrink = drinksRepository.GetDrinkById(drinkId);
            if (selectedDrink != null)
            {
                shoppingCart.AddToCart(selectedDrink, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int drinkId)
        {
            var selectedDrink = drinksRepository.GetDrinkById(drinkId);
            if (selectedDrink != null)
            {
                shoppingCart.RemoveFromCart(selectedDrink);
            }
            return RedirectToAction("Index");
        }
    }
}
