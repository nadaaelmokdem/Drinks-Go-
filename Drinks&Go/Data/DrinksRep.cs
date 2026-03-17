using Drinks_Go.Interfaces;
using Drinks_Go.Models;
using Microsoft.EntityFrameworkCore;

namespace Drinks_Go.Data
{
    public class DrinksRep : IDrinksRepository
    {
        private readonly Appdbcontext appdbcontext;
        public DrinksRep (Appdbcontext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }
        public IEnumerable<Drink> Drinks => appdbcontext.Drinks.Include(c => c.Category);

        public IEnumerable<Drink> PreferredDrinks => appdbcontext.Drinks.Where(p => p.IsPreferredDrink).Include(c => c.Category);

        public Drink GetDrinkById(int drinkId) => appdbcontext.Drinks.FirstOrDefault(p => p.DrinkId == drinkId);
    }
}
