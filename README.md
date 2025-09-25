🧑‍💻 User & Tasks Management API

A simple ASP.NET Core Web API project for managing Users and their Tasks, built with Entity Framework Core and SQL Server.
The project demonstrates clean API design, DTO usage, CRUD operations, and Swagger integration.

🚀 Features

✨ Create, Read, Update, Delete (CRUD) for Users.

📌 Each user can have Tasks with:

Title

Description

Status (enum-based).

🔍 Swagger UI integration for easy testing.

🗄️ Entity Framework Core for database access.

✅ DTOs for clean API responses.

📂 Project Structure
├── Controllers
│   └── UsersController.cs
├── DTOs
│   ├── UserDto.cs
│   ├── TaskDto.cs
│   ├── UserCreateDto.cs
│   └── UserUpdateDto.cs
├── Models
│   ├── User.cs
│   └── TaskItem.cs
├── Data
│   └── AppDbContext.cs
└── Program.cs

⚡ How to Run

Clone the repository:

git clone https://github.com/your-username/UsersTasksAPI.git
cd UsersTasksAPI


Update appsettings.json with your SQL Server connection string.

Run migrations:

dotnet ef database update


Run the project:

dotnet run


Open Swagger:

https://localhost:7228/swagger

🛠 Example Request
➕ Create User with Task

POST /api/users

Form-data:

Name=Omar
Email=user@example.com
TaskTitle=Playing
TaskDescription=Joy
TaskStatus=1


Response

{
  "id": 1,
  "name": "Omar",
  "email": "user@example.com",
  "tasks": [
    {
      "id": 1,
      "title": "Playing",
      "description": "Joy",
      "status": 1
    }
  ]
}

📸 Swagger Screenshot

🏗️ Future Improvements

🔄 Pagination & Filtering for users.

🔒 Authentication & Authorization.

📊 Better Task Status enums (e.g. Pending, InProgress, Done).

👤 Author

Seif Amr
