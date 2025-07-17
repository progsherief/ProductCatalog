# 🛒 Product Catalog Web Application

This is a web-based **Product Catalog System** built using **.NET 8**, following **Clean Architecture**, 
and leveraging **Entity Framework Core**, **Generic Repository**,
**Unit of Work**, and **Specification Design Pattern**.

---

## 📦 Technologies Used

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- MSSQL Server
- Clean Architecture
- AutoMapper
- Identity (Roles: Admin, User)
- CSV Import
- File Upload (Images – JPG, PNG)
- xUnit Testing

---

## ✅ Features

- Admin authentication and authorization
- Add, Edit, Delete products (Admin only)
- Product filtering by category
- Show only currently available products
- Product image upload with validation
- Bulk product import from CSV
- Product history log on each update
- Error handling and logging

---

## 🗂️ Solution Structure

```
ProductCatalog.sln
│
├── ProductCatalog.Domain           // Entities & Interfaces
├── ProductCatalog.Application      // Use Cases & Services
├── ProductCatalog.Infrastructure   // EF Repositories, DbContext
└── ProductCatalog.WebUI            // MVC UI, Controllers, Views, Identity
```

---

## 🛠️ Getting Started

### 1. Clone the repo
```bash
git clone https://github.com/progsherief/ProductCatalog.git
```

### 2. Setup database
- Update your `appsettings.json` with your SQL Server connection string
- Apply migrations using:
```bash
Update-Database
```

### 3. Run the app
```bash
dotnet run
```

---

## 🧪 Testing

Unit tests available using `xUnit` in a separate test project.

---

## 📸 Screenshots


## 📧 Contact

For any inquiries or suggestions:

**Developer:** [progsherief@gmail.com](mailto:progsherief@gmail.com)

---

**⭐ Don't forget to star the repo if you like it!**