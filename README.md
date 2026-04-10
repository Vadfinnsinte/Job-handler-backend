# Job-handler-backend

## About the project

This is the backend for **Job Handler**, a fullstack application built with ASP.NET Core Web API.  
The API is responsible for handling authentication, authorization, users, posts, and comments, and is designed to work together with a React frontend.

---

## Features

- User registration and login  
- JWT-based authentication  
- Role-based authorization (Admin / User)  
- CRUD operations for posts  
- CRUD operations for comments  
- Admin functionality for managing users  

---

## Tech stack

- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- ASP.NET Core Identity  
- JWT Authentication  

---

## API Structure

The API follows a layered architecture:

- **Controllers** handle HTTP requests and responses  
- **Services** contain business logic  
- **Models** represent database entities  
- **DTOs** are used to transfer data between backend and frontend  

This separation improves maintainability, scalability, and readability.

---

## Main Endpoints

### Auth
- POST /api/auth/register  
- POST /api/auth/login  

### Post
- GET /api/post  
- GET /api/post/my-posts  
- POST /api/post  
- PUT /api/post/{id}  
- DELETE /api/post/{id}  
- DELETE /api/post/admin/{id}  

### Comment
- GET /api/comment  
- GET /api/comment/{postId}  
- POST /api/comment  
- PUT /api/comment/{id}  
- DELETE /api/comment/{id}  

### User
- GET /api/user  

---

## Validation and Error Handling

The API includes validation and structured error handling to ensure stability and a better developer experience.

Examples:

- Empty fields are not allowed  
- Text length is validated  
- Resources must exist before update or delete  
- A custom `Result<T>` pattern is used to return success and error responses  

---

## How to run the project

1. Clone the repository  
2. Open the project in Visual Studio or VS Code  
3. Configure `appsettings.json` (database and JWT settings)  
4. Run database migrations  
5. Start the API  

Example:

dotnet ef database update
dotnet run


### Testing

- The API has been tested using:

- Swagger
- Postman

### Project Purpose

The purpose of this project is to build a fullstack application with authentication, API, database, and frontend integration.

### Authors

This project was created as a group assignment.


## Data Model

```mermaid
erDiagram
    USER ||--o{ POST : creates
    USER ||--o{ COMMENT : writes
    POST ||--o{ COMMENT : has

    USER {
        string Id
        string UserName
        string Email
        string Name
        bool EmploymentStatus
        datetime Created
    }

    POST {
        guid Id
        string Title
        string CompanyName
        string Link
        string Status
        string AdText
        datetime Created
        datetime Updated
        datetime ApplicationDate
        string UserId
    }

    COMMENT {
        guid Id
        string Text
        datetime CreationDate
        datetime UpdatedDate
        string UserId
        guid PostId
    }

