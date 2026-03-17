using Drinks_Go.Models;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Drinks_Go.Data
{
    public class DbInitializer
    {
        public static void Seed(Appdbcontext context)
        {
            // Add Categories if not exist
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            // Add Drinks if not exist
            if (!context.Drinks.Any())
            {
                context.AddRange
                (
                    new Drink
                    {
                        Name = "Cappuccino",
                        Price = 50,
                        ShortDescription = "Classic Italian coffee",
                        LongDescription = "Classic Italian coffee drink prepared with espresso, hot milk, and steamed milk foam.",
                        Category = Categories["Hot Drinks"],
                        ImageUrl = "Cappuccino.jpg",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = "Cappuccino.jpg"
                    },
                    new Drink
                    {
                        Name = "Hot Chocolate",
                        Price = 60,
                        ShortDescription = "Creamy chocolate drink.",
                        LongDescription = "A rich and comforting drink made with milk and cocoa powder, topped with cream.",
                        Category = Categories["Hot Drinks"],
                        ImageUrl = "choco-milk.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = ""
                    },

                    new Drink
                    {
                        Name = "Iced Latte",
                        Price = 55,
                        ShortDescription = "Chilled espresso with milk.",
                        LongDescription = "A refreshing cold drink made with espresso, milk, and ice cubes.",
                        Category = Categories["Cold Drinks"],
                        ImageUrl = "Iced-Latte.jpg",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = ""
                    },
                    new Drink
                    {
                        Name = "Iced Tea Lemon",
                        Price = 50,
                        ShortDescription = "Lemon-flavored iced tea.",
                        LongDescription = "A light, refreshing cold tea infused with lemon flavor.",
                        Category = Categories["Cold Drinks"],
                        ImageUrl = "Iced-Tea.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = ""
                    },
                    new Drink
                    {
                        Name = "Orange Juice",
                        Price = 40,
                        ShortDescription = "Freshly squeezed orange juice.",
                        LongDescription = "A healthy and refreshing drink made from freshly squeezed oranges.",
                        Category = Categories["Fresh Juices"],
                        ImageUrl = "Orange-Jucie.jpg",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = ""
                    },
                    new Drink
                    {
                        Name = "Mango Juice",
                        Price = 70,
                        ShortDescription = "Sweet tropical mango juice.",
                        LongDescription = "A delicious, naturally sweet juice made from ripe mangoes.",
                        Category = Categories["Fresh Juices"],
                        ImageUrl = "Mango_jucie.jpg",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = ""
                    },
                    new Drink
                    {
                        Name = "Strawberry Smoothie",
                        Price = 80,
                        ShortDescription = "Creamy strawberry blend.",
                        LongDescription = "A thick and creamy smoothie made with fresh strawberries and yogurt.",
                        Category = Categories["Smoothies & Milkshakes"],
                        ImageUrl = "straw.jpg",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = ""
                    },
                    new Drink
                    {
                        Name = "Chocolate Milkshake",
                        Price = 90,
                        ShortDescription = "Rich chocolate milkshake.",
                        LongDescription = "A decadent milkshake made with chocolate ice cream and milk, topped with whipped cream.",
                        Category = Categories["Smoothies & Milkshakes"],
                        ImageUrl = "choco-milk.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = ""
                    },
                    new Drink
                    {
                        Name = "Virgin Mojito",
                        Price = 100,
                        ShortDescription = "Refreshing mint and lime mocktail.",
                        LongDescription = "A cool and refreshing non-alcoholic cocktail made with fresh mint, lime juice, sugar, and soda water.",
                        Category = Categories["Mocktails & Specials"],
                        ImageUrl = "vigin.jpg",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = ""
                    },
                    new Drink
                    {
                        Name = "Pina Colada Mocktail",
                        Price = 120,
                        ShortDescription = "Tropical pineapple and coconut drink.",
                        LongDescription = "A creamy and tropical non-alcoholic cocktail made with pineapple juice, coconut milk, and ice.",
                        Category = Categories["Mocktails & Specials"],
                        ImageUrl = "pina.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = ""
                    },
                    new Drink
                    {
                        Name = "Mineral Water",
                        Price = 20.00M,
                        ShortDescription = "Pure and refreshing mineral water.",
                        LongDescription = "Bottled mineral water sourced from natural springs, perfect for hydration.",
                        Category = Categories["Water & Soft Drinks"],
                        ImageUrl = "water.jpg",
                        InStock = true,
                        IsPreferredDrink = true,
                        ImageThumbnailUrl = ""
                    },
                    new Drink
                    {
                        Name = "Cola",
                        Price = 15.00M,
                        ShortDescription = "Classic soft drink.",
                        LongDescription = "Chilled carbonated soft drink served cold.",
                        Category = Categories["Water & Soft Drinks"],
                        ImageUrl = "cola.jpg",
                        InStock = true,
                        IsPreferredDrink = false,
                        ImageThumbnailUrl = ""
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, category> categories;
        public static Dictionary<string, category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var catList = new category[]
                    {
                        new category { CategoryName = "Hot Drinks", Description="Warm and cozy beverages" },
                        new category { CategoryName = "Cold Drinks", Description="Iced and refreshing drinks" },
                        new category { CategoryName = "Fresh Juices", Description="Healthy and natural juices" },
                        new category { CategoryName = "Smoothies & Milkshakes", Description="Creamy and fruity blends" },
                        new category { CategoryName = "Mocktails & Specials", Description="Fancy non-alcoholic cocktails" },
                        new category { CategoryName = "Water & Soft Drinks", Description="Essential and fizzy drinks" }
                    };

                    categories = new Dictionary<string, category>();
                    foreach (category cat in catList)
                    {
                        categories.Add(cat.CategoryName, cat);
                    }
                }

                return categories;
            }
        }
    }
}
