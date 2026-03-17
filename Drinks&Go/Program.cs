using Drinks_Go.Data;
using Drinks_Go.Interfaces;
using Drinks_Go.Mocks;
using Drinks_Go.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRep>();
builder.Services.AddScoped<IDrinksRepository, DrinksRep>();
builder.Services.AddScoped<IOrderRepository, OrderRep>();


// Register DbContext
builder.Services.AddDbContext<Appdbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<Appdbcontext>();

// Register ShoppingCart
builder.Services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));

// Register HttpContextAccessor and Session
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session BEFORE authorization
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "categoryFilter",
    pattern: "Drinks/{action}/{category?}",
    defaults: new { controller = "Drinks", action = "List" });

// Seed Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Appdbcontext>();

    context.Database.EnsureCreated();

    DbInitializer.Seed(context);
}

app.Run();
