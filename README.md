# Sales Store API

![status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)
![language](https://img.shields.io/badge/language-C%23-purple)
![framework](https://img.shields.io/badge/framework-.NET%209-blue)

## About

An API for a retail store, adding complex business rules and handling the entire business flow involving the necessary entities in a store.

## Endpoints

* `POST /api/products`
* `GET /api/products`
* `GET /api/products/id`
* `PUT /api/products/id`
* `DELETE /api/products/id`

## Prerequisites

* [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
* [PostgreSQL](https://www.postgresql.org/download/)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

## Installation

1. **Clone the repository:** `https://github.com/D-Luan/sales-store-api.git`

2. **Navigate to the WebAPI project folder:** `cd src/SalesStore.WebAPI`

3. **Initialize User Secrets:** `dotnet user-secrets init`

4. **Set your connection string:** `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=YourDbName;Username=YourUser;Password=YourPassword;"`

5. **Apply the Database Migrations:** `dotnet ef database update`

6. **Run the Application:** `dotnet run`

## Stack

- **Technologies**: C#, .NET 9, ASP.NET Core Web API, PostgreSQL, Entity Framework Core
- **Tools**: Git, Visual Studio 2022, Swagger/OpenAPI
- **Agile Methodology**: Kanban

## License

Distributed under the MIT License. See the [LICENSE](./LICENSE) for more information.