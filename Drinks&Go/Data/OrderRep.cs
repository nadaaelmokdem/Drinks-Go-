using Drinks_Go.Interfaces;
using Drinks_Go.Models;

namespace Drinks_Go.Data
{
    public class OrderRep : IOrderRepository
    {
        private readonly Appdbcontext appdbcontext;
        private readonly ShoppingCart shoppingCart;

        public OrderRep(Appdbcontext appdbcontext, ShoppingCart shoppingCart)
        {
            this.appdbcontext = appdbcontext;
            this.shoppingCart = shoppingCart;
        }

        public void createOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            appdbcontext.Orders.Add(order);
            appdbcontext.SaveChanges();

            var shoppingcartitems = shoppingCart.ShoppingCartItems;
            foreach (var item in shoppingcartitems)
            {
                var orderdetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    DrinkId = item.Drink.DrinkId,
                    OrderId = order.OrderId,
                    Price = item.Drink.Price
                };
                appdbcontext.OrderDetails.Add(orderdetail);
            }

            appdbcontext.SaveChanges();
        }
    }
}