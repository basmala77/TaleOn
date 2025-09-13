## TaleOn - Interactive Story Management System

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Swagger](https://img.shields.io/badge/Docs-Swagger-85EA2D)](https://localhost:5001/swagger)

> **Note**: This is the Backend API for TaleOn. For mobile app, see [TaleOn_Mobile](https://github.com/yourusername/TaleOn_Mobile).
> **Screenshots**: Will be added soon once UI is finalized.

## 📋 Table of Contents
- [Overview](#-overview)
- [Features](#-key-features)
- [API Endpoints](#-api-endpoints)
- [Requirements](#-requirements)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [Technical Documentation](#-technical-documentation)
- [Contributing](#-contributing)

## 🌟 Overview

TaleOn is an integrated interactive story management system, specifically designed to provide a rich and smooth user experience. The system is built on a modern and scalable architecture using the latest .NET technologies.

### 🖥️ Tech Stack

- **Backend Framework**: ASP.NET Core 9.0
- **Database**: SQL Server with Entity Framework Core
- **Caching**: Redis
- **Authentication**: JWT + OTP
- **Payment Processing**: PayPal Sandbox Integration
- **API Documentation**: Swagger UI + Scalar
- **Containerization**: Docker (Optional)

### Screenshots

| Swagger UI | 
|------------|
|<img width="1080" height="1920" alt="Screenshot 2025-09-13 234723" src="https://github.com/user-attachments/assets/0d835b30-c2f1-4eaf-a286-71957334f65f" />
 |

## ✨ Key Features

### 🔒 Authentication System
- JWT-based authentication
- Email verification via OTP
- User roles and permissions management

### 💳 PayPal Integration (Sandbox Only)
- Secure payment processing via PayPal Sandbox
- Basic transaction creation and capture
- Payment status tracking in database

### ⚡ Performance
- Redis caching system
- Fast data loading
- Efficient request handling
- Asynchronous operations for better scalability

### 📚 Story Generation
- AI-powered story generation
- Image generation for story scenes
- Multi-language support (Arabic)
- Interactive story progression

### 💳 Payment System
- PayPal integration for secure payments
- Payment status tracking
- Sandbox environment for testing

### 📱 API Features
- Interactive documentation with Swagger
- Full RESTful API support
- Identity authentication
- Role-based access control
- Input validation
- Global exception handling

## 🌐 API Documentation

Explore our complete API documentation and test the endpoints using our Postman collection:

[![Run in Postman](https://run.pstmn.io/button.svg)](https://taleon-3533.postman.co/workspace/TaleOn~66e851b1-779b-47da-abcf-3bbbb47c4ef7/collection/42507542-8dbf6a81-ee9c-41d8-b229-0f2600135bff?action=share&source=copy-link&creator=42507542)

## 📚 API Endpoints

### Authentication
- `POST /api/Auth/login` - User login
- `POST /api/Auth/register` - User registration
- `POST /api/Auth/verify-otp` - OTP verification

### Parent Features
- `GET /api/Parent/profile` - Get parent profile
- `PUT /api/Parent/update-profile` - Update parent profile

### Child Features
- `GET /api/Children` - Get child
- `POST /api/Children` - Create child 
- `PUT /api/Children/{id}` - Update child
- `PUT /api/Children/{id}` - Get interests
- `PUT /api/Children/{id}` - Add interests
- `GET /api/Children/{id}/stories` - Get child's stories

### Story Features
- `POST /api/Story/generate` - Generate story

### Payment Features
- `GET /api/Payment/token` - Get payment token
- `POST /api/Payment/create-order` - Create payment order

## 🛠️ Quick Start

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server 2019+](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Redis Server](https://redis.io/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Configuration

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/TaleOn_BackEnd.git
   cd TaleOn_BackEnd
   ```

2. Update `appsettings.json` with your configuration:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=TaleOnDB;Trusted_Connection=True;TrustServerCertificate=True;"
     },
     "Jwt": {
       "Key": "YourSuperSecretKey_Minimum32CharactersLong"
     },
     "Redis": {
       "Configuration": "localhost:6379"
     },
     "PayPal": {
       "ClientId": "YourPayPalClientId",
       "ClientSecret": "YourPayPalSecret"
     }
   }
   ```

3. Apply database migrations:
   ```bash
   cd AcessData
   dotnet ef database update --startup-project ../TaleOn
   ```

4. Run the application:
   ```bash
   dotnet run --project TaleOn
   ```

5. Access the API documentation:
   - Swagger UI: https://localhost:5001/swagger
   - Scalar: https://localhost:5001/scalar

### Supported Browsers
- Chrome (latest version)
- Firefox (latest version)
- Edge (latest version)

## 🚀 Getting Started

1. **Clone the repository**
   ```bash
   git clone [repository-url]
   cd TaleOn_BackEnd
   ```

2. **Install required packages**
   ```bash
   dotnet restore
   ```

3. **Configure the database**
   - Open `appsettings.json`
   - Update the database connection string
   - Configure Redis settings

4. **Apply database migrations**
   ```bash
   cd AcessData
   dotnet ef database update --startup-project ../TaleOn
   ```

5. **Run the application**
   ```bash
   cd ..
   dotnet run --project TaleOn
   ```

## 🏗️ Project Structure

```
TaleOn_BackEnd/
├── AcessData/          # Data access layer and database context
├── Models/             # Domain models and DTOs
├── TaleOn/             # Main API project (Startup, Controllers)
├── TaleOn.Services/    # Business logic services
└── README.md           # Project documentation
```

## 📚 Technical Documentation

### API Endpoints
- `POST /api/AuthUser/register` - Register new user
- `POST /api/AuthUser/login` - User login
- `POST /api/AuthUser/verify-otp` - Verify email with OTP
- `GET /api/Child` - Get children list
- `POST /api/Child` - Add new child
- `GET /api/Parent` - Get parent details
- `POST /api/Payment` - Create payment
- `GET /api/Payment/capture/{orderId}` - Capture payment

#### Database
- `ConnectionStrings:DefaultConnection` - SQL Server connection string

#### Authentication
- `Jwt:Key` - JWT encryption key

#### Caching
- `Redis:Configuration` - Redis connection settings

#### PayPal Configuration (Required)
- `PayPal:ClientId` - Your PayPal Sandbox API client ID
- `PayPal:ClientSecret` - Your PayPal Sandbox API secret key

## 🤝 Contributing to TaleOn

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Run tests to ensure everything works
5. Commit your changes (`git commit -m 'Add some amazing feature'`)
6. Push to the branch (`git push origin feature/amazing-feature`)
7. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

<div align="center">
  Made with ❤️ by Your Team | 2025
</div>
