namespace Drinks_Go.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public string ShoppingCartId { get; set; }

        public int DrinkId { get; set; }
        public Drink Drink { get; set; }

        public int Amount { get; set; }
    }
}
