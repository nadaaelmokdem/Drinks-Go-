using Drinks_Go.Data;
using Drinks_Go.Interfaces;
using Drinks_Go.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRep>();
builder.Services.AddScoped<IDrinksRepository, DrinksRep>();
builder.Services.AddScoped<IOrderRepository, OrderRep>();

// Register DbContext — use PostgreSQL on Railway, SQL Server locally
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

if (!string.IsNullOrEmpty(databaseUrl))
{
    // Running on Railway — use PostgreSQL
    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':');
    var pgConnection = $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={userInfo[1]}";

    builder.Services.AddDbContext<Appdbcontext>(options =>
        options.UseNpgsql(pgConnection));
}
else
{
    // Running locally — use SQL Server
    builder.Services.AddDbContext<Appdbcontext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

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

app.Run($"http://0.0.0.0:{port}");