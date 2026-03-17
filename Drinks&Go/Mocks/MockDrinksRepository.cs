using Drinks_Go.Models;
using Drinks_Go.Interfaces;

namespace Drinks_Go.Mocks
{
    public class MockDrinksRepository : IDrinksRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Drink> Drinks => new List<Drink>
        {
            // Hot Drinks
            new Drink {
                DrinkId = 1,
                Name = "Cappuccino",
                Price = 25.00M,
                ShortDescription = "Espresso with steamed milk foam.",
                LongDescription = "Classic Italian coffee drink prepared with espresso, hot milk, and steamed milk foam.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Hot Drinks"),
                ImageUrl = "",
                InStock = true,
                IsPreferredDrink = true,
                ImageThumbnailUrl = ""
            },
            new Drink {
                DrinkId = 2,
                Name = "Hot Chocolate",
                Price = 20.00M,
                ShortDescription = "Creamy chocolate drink.",
                LongDescription = "A rich and comforting drink made with milk and cocoa powder, topped with cream.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Hot Drinks"),
                ImageUrl = "",
                InStock = true,
                IsPreferredDrink = false,
                ImageThumbnailUrl = ""
            },

            // Cold Drinks
            new Drink {
                DrinkId = 3,
                Name = "Iced Latte",
                Price = 30.00M,
                ShortDescription = "Chilled coffee with milk.",
                LongDescription = "Refreshing iced latte made with espresso and cold milk served over ice.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Cold Drinks"),
                ImageUrl = "",
                InStock = true,
                IsPreferredDrink = false,
                ImageThumbnailUrl = ""
            },
            new Drink {
                DrinkId = 4,
                Name = "Iced Tea Lemon",
                Price = 18.00M,
                ShortDescription = "Chilled tea with lemon flavor.",
                LongDescription = "Cool and refreshing iced tea infused with lemon flavor.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Cold Drinks"),
                ImageUrl = "",
                InStock = true,
                IsPreferredDrink = false,
                ImageThumbnailUrl = ""
            },

            // Fresh Juices
            new Drink {
                DrinkId = 5,
                Name = "Orange Juice",
                Price = 22.00M,
                ShortDescription = "Freshly squeezed orange juice.",
                LongDescription = "Natural juice made from fresh oranges, no sugar added.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Fresh Juices"),
                ImageUrl = "https://images.unsplash.com/photo-1577803645773-f96470509666",
                InStock = true,
                IsPreferredDrink = true,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1577803645773-f96470509666?w=200"
            },
            new Drink {
                DrinkId = 6,
                Name = "Mango Juice",
                Price = 28.00M,
                ShortDescription = "Tropical mango juice.",
                LongDescription = "Delicious mango juice with a naturally sweet tropical flavor.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Fresh Juices"),
                ImageUrl = "https://images.unsplash.com/photo-1622489914388-9a635fbc9a2f",
                InStock = true,
                IsPreferredDrink = false,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1622489914388-9a635fbc9a2f?w=200"
            },

            // Smoothies & Milkshakes
            new Drink {
                DrinkId = 7,
                Name = "Strawberry Smoothie",
                Price = 35.00M,
                ShortDescription = "Smooth blend of strawberries and yogurt.",
                LongDescription = "Refreshing and healthy smoothie made with fresh strawberries and low-fat yogurt.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Smoothies & Milkshakes"),
                ImageUrl = "https://images.unsplash.com/photo-1524592094714-0f0654e20314",
                InStock = true,
                IsPreferredDrink = false,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1524592094714-0f0654e20314?w=200"
            },
            new Drink {
                DrinkId = 8,
                Name = "Chocolate Milkshake",
                Price = 32.00M,
                ShortDescription = "Rich chocolate shake with milk.",
                LongDescription = "Creamy and indulgent milkshake made with chocolate syrup and milk.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Smoothies & Milkshakes"),
                ImageUrl = "https://images.unsplash.com/photo-1590080876273-5c88dbf47c52",
                InStock = true,
                IsPreferredDrink = true,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1590080876273-5c88dbf47c52?w=200"
            },

            // Mocktails & Specials
            new Drink {
                DrinkId = 9,
                Name = "Virgin Mojito",
                Price = 40.00M,
                ShortDescription = "Mint and lime mocktail.",
                LongDescription = "Refreshing mocktail made with mint, lime juice, and soda water.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Mocktails & Specials"),
                ImageUrl = "https://images.unsplash.com/photo-1623065428777-7bdeed3dfb62",
                InStock = true,
                IsPreferredDrink = true,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1623065428777-7bdeed3dfb62?w=200"
            },
            new Drink {
                DrinkId = 10,
                Name = "Blue Lagoon (Non-alcoholic)",
                Price = 38.00M,
                ShortDescription = "Fruity blue mocktail.",
                LongDescription = "Bright and tropical mocktail with lemonade and sprite.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Mocktails & Specials"),
                ImageUrl = "https://images.unsplash.com/photo-1600271886004-2848b28c39d4",
                InStock = true,
                IsPreferredDrink = false,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1600271886004-2848b28c39d4?w=200"
            },

            // Water & Soft Drinks
            new Drink {
                DrinkId = 11,
                Name = "Mineral Water",
                Price = 10.00M,
                ShortDescription = "Still bottled water.",
                LongDescription = "Pure natural bottled mineral water.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Water & Soft Drinks"),
                ImageUrl = "https://images.unsplash.com/photo-1581579188871-45ea61f2a0c8",
                InStock = true,
                IsPreferredDrink = false,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1581579188871-45ea61f2a0c8?w=200"
            },
            new Drink {
                DrinkId = 12,
                Name = "Cola",
                Price = 15.00M,
                ShortDescription = "Classic soft drink.",
                LongDescription = "Chilled carbonated soft drink served cold.",
                Category = _categoryRepository.Categories.First(c => c.CategoryName == "Water & Soft Drinks"),
                ImageUrl = "https://images.unsplash.com/photo-1603398938378-e54eab4466e4",
                InStock = true,
                IsPreferredDrink = false,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1603398938378-e54eab4466e4?w=200"
            }
        };

        public IEnumerable<Drink> PreferredDrinks => Drinks.Where(d => d.IsPreferredDrink);

        public Drink GetDrinkById(int drinkId) =>
            Drinks.FirstOrDefault(d => d.DrinkId == drinkId);
    }
}
