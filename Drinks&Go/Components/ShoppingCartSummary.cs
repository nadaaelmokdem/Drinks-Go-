using Drinks_Go.Models;
using Microsoft.AspNetCore.Mvc;

namespace Drinks_Go.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            var total = shoppingCart.GetCartTotal();
            ViewBag.Total = total;
            return View(shoppingCart);
        }
    }
}
