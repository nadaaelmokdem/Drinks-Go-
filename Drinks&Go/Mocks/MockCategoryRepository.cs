using Drinks_Go.Models;
using Drinks_Go.Interfaces;


namespace Drinks_Go.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<category> Categories
        {
            get
            {
                return new List<category>
                { 
                    new category { CategoryId = 1, CategoryName = "Hot Drinks", Description = "Warm and cozy drinks" },
            new category { CategoryId = 2, CategoryName = "Cold Drinks", Description = "Chilled coffee and teas" },
            new category { CategoryId = 3, CategoryName = "Fresh Juices", Description = "Natural fruit juices" },
            new category { CategoryId = 4, CategoryName = "Smoothies & Milkshakes", Description = "Sweet and creamy blended drinks" },
            new category { CategoryId = 5, CategoryName = "Mocktails & Specials", Description = "Special mixed drinks without alcohol" },
            new category { CategoryId = 6, CategoryName = "Water & Soft Drinks", Description = "Basic drinks for everyone" }
                };
            }
        }
    }
}
