using Drinks_Go.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Drinks_Go.Models
{
    public class ShoppingCart
    {
        private readonly Appdbcontext _appdbcontext;

        public ShoppingCart(Appdbcontext appdbcontext)
        {
            _appdbcontext = appdbcontext;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            // Get the session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // Get the context
            var context = services.GetRequiredService<Appdbcontext>();

            // Get or create the cart ID
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            // Save the cart ID in session
            session.SetString("CartId", cartId);

            // Return a new ShoppingCart instance with context
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Drink drink, int amount)
        {
            var cartItem = _appdbcontext.ShoppingCartItems.SingleOrDefault(
                s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            if (cartItem == null)
            {
                cartItem = new ShoppingCartItem
                {
                    Drink = drink,
                    Amount = amount,
                    ShoppingCartId = ShoppingCartId
                };

                _appdbcontext.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                cartItem.Amount += amount;
            }

            _appdbcontext.SaveChanges();
        }

        public void RemoveFromCart(Drink drink)
        {
            var cartItem = _appdbcontext.ShoppingCartItems.SingleOrDefault(
                s => s.Drink.DrinkId == drink.DrinkId && s.ShoppingCartId == ShoppingCartId);

            if (cartItem != null)
            {
                if (cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                }
                else
                {
                    _appdbcontext.ShoppingCartItems.Remove(cartItem);
                }
            }

            _appdbcontext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = _appdbcontext.ShoppingCartItems
                    .Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Include(s => s.Drink)
                    .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appdbcontext.ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appdbcontext.ShoppingCartItems.RemoveRange(cartItems);
            _appdbcontext.SaveChanges();
        }

        public decimal GetCartTotal()
        {
            return _appdbcontext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Drink.Price * c.Amount)
                .Sum();
        }
    }
}
