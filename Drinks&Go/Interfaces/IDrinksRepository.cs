using Drinks_Go.Models;

namespace Drinks_Go.Interfaces
{
    public interface IDrinksRepository
    {

        IEnumerable<Drink> Drinks { get; }
        IEnumerable<Drink> PreferredDrinks { get; }
        Drink GetDrinkById(int drinkId);
    }
}
