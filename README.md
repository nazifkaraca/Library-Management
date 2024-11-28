<h1 align="center">Karaca Library</h1>

An **ASP.NET Core MVC** application for managing a library's book and author operations. This project demonstrates the use of **Object-Oriented Programming (OOP)** principles, **Entity Framework Core**, and **Dependency Injection (DI)** to build a robust and scalable web application.

![image](https://github.com/user-attachments/assets/0b146a55-6188-4ef6-90f8-92fc55f90ddf)

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

---

## Overview

The Library Management System allows users to perform CRUD (Create, Read, Update, Delete) operations for managing books and authors. It includes features such as listing books and authors, viewing detailed information, and managing library inventory. The application follows the **Model-View-Controller (MVC)** design pattern and is fully customizable for different library needs.

---

## Features

- **Books Management:**
  - List all books.
  - View detailed information about a book.
  - Add new books.
  - Edit existing book details.
  - Delete books.

- **Authors Management:**
  - List all authors.
  - View detailed information about an author.
  - Add new authors.
  - Edit existing author details.
  - Delete authors.

- **Home & About Pages:**
  - A customizable homepage.
  - An informational About page.

- **Reusable Components:**
  - **Layout** for consistent site structure.
  - **Partial Views** for reusability across views.
  - **Footer** with copyright information.

---

## Technologies Used

- **C#**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **Dependency Injection**
- **Bootstrap** (for responsive UI)
- **Migrations** for database management

---

## Installation

Follow these steps to set up the project locally:

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/library-management-system.git
   cd library-management-system
   ```

2. **Restore Dependencies**
   Ensure you have the .NET SDK installed. Run the following command:
   ```bash
   dotnet restore
   ```

3. **Database Configuration**
   - Update the `appsettings.json` file with your database connection string:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Your-Database-Connection-String"
     }
     ```
   - Apply the migrations to set up the database schema:
     ```bash
     dotnet ef database update
     ```

4. **Run the Application**
   Start the development server:
   ```bash
   dotnet run
   ```

5. **Access the Application**
   Open your browser and navigate to:
   ```
   http://localhost:5000
   ```

---

## Usage

### Book Management
- Navigate to the **Books** section to:
  - View a list of books.
  - Add, edit, or delete books.

### Author Management
- Navigate to the **Authors** section to:
  - View a list of authors.
  - Add, edit, or delete authors.

### Additional Pages
- Visit the **Home** page for an overview.
- Explore the **About** page for more information about the project.

---

## Project Structure

```
## Project Structure

LibraryManagementSystem/  
├── Controllers/  
│   ├── AuthorController.cs          # Handles author-related actions  
│   ├── BookController.cs            # Handles book-related actions  
│   └── DefaultController.cs         # Handles home and default actions  
├── DAL/  
│   ├── Context/  
│   │   └── LibraryContext.cs        # Entity Framework Core DbContext configuration  
│   ├── Entities/  
│   │   ├── Author.cs                # Author entity/model  
│   │   └── Book.cs                  # Book entity/model  
├── Migrations/  
│   ├── 20241122121121_initialmig.cs   # Initial database migration  
│   └── LibraryContextModelSnapshot.cs # Migration snapshot file  
├── Services/  
│   ├── AuthorService.cs             # Business logic for authors  
│   ├── BookService.cs               # Business logic for books  
│   ├── IAuthorService.cs            # Interface for AuthorService  
│   └── IBookService.cs              # Interface for BookService  
├── ViewModels/  
│   ├── AuthorViewModel.cs           # ViewModel for author-related views  
│   └── BookViewModel.cs             # ViewModel for book-related views  
├── Views/  
│   ├── Author/  
│   │   ├── CreateAuthor.cshtml      # Form for creating an author  
│   │   └── UpdateAuthor.cshtml      # Form for updating an author  
│   ├── Book/  
│   │   ├── CreateBook.cshtml        # Form for creating a book  
│   │   └── UpdateBook.cshtml        # Form for updating a book  
│   ├── Default/  
│   │   └── Index.cshtml             # Home page view  
│   ├── Shared/  
│   │   ├── _Layout.cshtml                   # Main layout view  
│   │   └── _ValidationScriptsPartial.cshtml # Partial for validation scripts  
│   └── ViewComponents/  
│       ├── _AboutComponentPartial.cs  # Partial for the About section  
│       ├── _AuthorComponentPartial.cs # Partial for displaying authors  
│       ├── _BookComponentPartial.cs   # Partial for displaying books  
│       ├── _FooterComponentPartial.cs   # Footer section partial  
│       ├── _HomepageComponentPartial.cs # Homepage-specific partial  
│       └── _ScriptsComponentPartial.cs  # Additional scripts partial  
└── Program.cs                           # Application entry point  
```
This structure organizes the project into logical sections like `Controllers`, `DAL` (Data Access Layer), `Services`, and `Views`. Each section has a clear role, making the application modular and easy to maintain.

---

## Key Configuration Details

### Dependency Injection
The project uses **Dependency Injection** to manage services like the database context. The `Program.cs` file configures services for MVC and Entity Framework Core:
```csharp
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### Routing
Default routing is set up to point to the `DefaultController`:
```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");
```

### Static Files
Static files (e.g., CSS, JavaScript) are served from the `wwwroot` folder.

---

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch.
3. Make your changes and commit them.
4. Submit a pull request.

---

## License

This project is licensed under the [MIT License](LICENSE).
