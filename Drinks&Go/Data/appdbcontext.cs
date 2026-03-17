using Microsoft.EntityFrameworkCore;
using Drinks_Go.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Drinks_Go.Data
{
    public class Appdbcontext : IdentityDbContext<IdentityUser>
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
        {
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}