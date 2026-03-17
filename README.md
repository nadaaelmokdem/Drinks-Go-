# 🥤 Drinks&Go

A full-stack ASP.NET Core MVC web application for browsing and ordering drinks online. Built with Entity Framework Core, ASP.NET Identity, and SQL Server.

---

## 📸 Features

- Browse drinks by category
- Add drinks to a shopping cart
- User registration and login (ASP.NET Identity)
- Checkout and place orders
- Order confirmation page
- Responsive UI with Bootstrap 5

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Framework | ASP.NET Core MVC (.NET 9) |
| Database | SQL Server |
| ORM | Entity Framework Core |
| Auth | ASP.NET Core Identity |
| Frontend | Bootstrap 5, Razor Views |
| Session | ASP.NET Core Session |

---

## ⚙️ Getting Started (Local Development)

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/) or later
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (any edition)
- [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (optional)

### Setup Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/YOUR_USERNAME/DrinksGo.git
   cd DrinksGo
   ```

2. **Update the connection string**

   Open `appsettings.json` and update the `DefaultConnection` to point to your SQL Server:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=Drinks;Integrated Security=True;TrustServerCertificate=True;"
   }
   ```
   Replace `YOUR_SERVER_NAME` with your SQL Server instance name (e.g. `localhost` or `.\SQLEXPRESS`).

3. **Run the project**

   Open the solution in Visual Studio and press **F5**, or run:
   ```bash
   dotnet run
   ```
   The database will be created and seeded automatically on first run.

4. **Register an account**

   Go to `/Account/Register` and create an account. Password must include uppercase, lowercase, number, and special character (e.g. `Test@123`).

---

## 📁 Project Structure

```
Drinks&Go/
├── Controllers/         # MVC Controllers (Account, Drinks, Order, etc.)
├── Data/                # DbContext and Repository implementations
├── Interfaces/          # Repository interfaces
├── Models/              # Entity models (Drink, Order, Category, etc.)
├── Views/               # Razor views
│   ├── Account/         # Login & Register pages
│   ├── Drinks/          # Drinks list page
│   ├── Order/           # Checkout & confirmation pages
│   ├── ShoppingCart/    # Cart page
│   └── Shared/          # Layout, partials, components
├── wwwroot/             # Static files (CSS, JS, images)
├── Program.cs           # App configuration and startup
└── appsettings.json     # Configuration (connection string, logging)
```

---

## 🐛 Known Bugs Fixed

During development the following bugs were identified and fixed:

- Category dropdown was pointing to wrong controller (`Drink` → `Drinks`)
- Login POST had `[Authorize]` instead of `[AllowAnonymous]`, blocking form submission
- Register page was missing `[AllowAnonymous]` on both GET and POST
- `_ViewImports.cshtml` had a broken tag helper reference to a non-existent project
- `ReturnUrl` and `OrderLines` were not nullable, causing silent form validation failures
- Order completion used `return View()` instead of `RedirectToAction`, breaking the confirmation page
- Database table names were lowercase (`order`, `orderDetails`) causing SQL errors
- Missing `City` field in Order model caused NULL constraint violation on save

---


## 🔐 Default Password Requirements

ASP.NET Identity requires passwords to have:
- At least 6 characters
- At least 1 uppercase letter
- At least 1 lowercase letter
- At least 1 number
- At least 1 special character

Example: `Test@123`

---

## 📄 License

This project is for educational purposes.
