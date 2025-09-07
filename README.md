🚀 Hekaity - Interactive Story Management System

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Swagger](https://img.shields.io/badge/Docs-Swagger-85EA2D)](https://localhost:5001/swagger)
[![Scalar](https://img.shields.io/badge/Docs-Scalar-1A1F35)](https://localhost:5001/scalar)

> **Note**: This is the Backend API for Hekaity. For mobile app, see [Hekaity_Mobile](https://github.com/yourusername/Hekaity_Mobile).
> **Screenshots**: Will be added soon once UI is finalized.

## 📋 Table of Contents
- [Overview](#-overview)
- [Features](#-key-features)
- [Requirements](#-requirements)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [Technical Documentation](#-technical-documentation)
- [Contributing](#-contributing)

## 🌟 Overview

Hekaity is an integrated interactive story management system, specifically designed to provide a rich and smooth user experience. The system is built on a modern and scalable architecture using the latest .NET technologies.

### 🖥️ Tech Stack

- **Backend Framework**: ASP.NET Core 9.0
- **Database**: SQL Server with Entity Framework Core
- **Caching**: Redis
- **Authentication**: JWT + OTP
- **Payment Processing**: PayPal Sandbox Integration
- **API Documentation**: Swagger UI + Scalar
- **Containerization**: Docker (Optional)

### 📱 Screenshots

| Swagger UI | 
|------------|
|<img width="1080" height="1365" alt="Screenshot 2025-09-07 202615" src="https://github.com/user-attachments/assets/59db1c75-5e2b-47f7-9efb-dc1a776797ab" />|

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

### 📱 API Features
- Interactive documentation with Swagger
- Full RESTful API support
- Detailed API documentation with Scalar

## 🛠️ Quick Start

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server 2019+](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Redis Server](https://redis.io/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Configuration

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/Hekaity_BackEnd.git
   cd Hekaity_BackEnd
   ```

2. Update `appsettings.json` with your configuration:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=HekaityDB;Trusted_Connection=True;TrustServerCertificate=True;"
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

6. **Open in browser**
   ```
   https://localhost:5001/swagger
   ```

## 📁 Project Structure

```
Hekaity_BackEnd/
├── TaleOn/              # Main API project
├── AccessData/          # Data access layer
├── Models/              # Data models and DTOs
├── TaleOn.Services/     # Business logic layer
└── Tests/               # Unit tests
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

### Environment Variables
The following environment variables are required:

#### Database
- `ConnectionStrings:DefaultConnection` - SQL Server connection string

#### Authentication
- `Jwt:Key` - JWT encryption key

#### Caching
- `Redis:Configuration` - Redis connection settings

#### PayPal Configuration (Required)
- `PayPal:ClientId` - Your PayPal Sandbox API client ID
- `PayPal:ClientSecret` - Your PayPal Sandbox API secret key

## 🧪 Running Tests

To run the test suite and verify everything is working correctly:

```bash
dotnet test
```

## 🐳 Docker Support

You can build and run the application using Docker:

```bash
# Build the Docker image
docker build -t hekaity-backend .

# Run the container
docker run -p 5001:5001 hekaity-backend
```

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Run tests to ensure everything works
5. Commit your changes (`git commit -m 'Add some amazing feature'`)
6. Push to the branch (`git push origin feature/amazing-feature`)
7. Open a Pull Request

## 📄 License

This project is licensed under the [MIT License](LICENSE).

## 📞 Support & Contact

For support, questions, or feature requests:
- 📧 Email: your.email@example.com
- 📝 [Open an Issue](https://github.com/yourusername/Hekaity_BackEnd/issues)
- 💬 Join our [Discord Server](https://discord.gg/your-invite-link)

---

<div align="center">
  Made with ❤️ by Hekaity Team
</div>


Hekaity is an integrated interactive story management system, specifically designed to provide a rich and smooth user experience. The system is built on a modern and scalable architecture using the latest .NET technologies.

## ✨ Key Features

### 🔒 Authentication System
- JWT-based authentication
- Email verification via OTP
- User roles and permissions management# 🚀 Hekaity - Interactive Story Management System

## 📋 Table of Contents
- [Overview](#-overview)
- [Features](#-key-features)
- [Requirements](#-requirements)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [Technical Documentation](#-technical-documentation)
- [Contributing](#-contributing)

## 🌟 Overview

Hekaity is an integrated interactive story management system, specifically designed to provide a rich and smooth user experience. The system is built on a modern and scalable architecture using the latest .NET technologies.

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

### 📱 API Features
- Interactive documentation with Swagger
- Full RESTful API support
- Detailed API documentation with Scalar

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



## 📁 Project Structure

```
TaleOn_BackEnd/
├── TaleOn/              # Main API project
├── AccessData/          # Data access layer
├── Models/              # Data models and DTOs
├── TaleOn.Services/     # Business logic layer
└── Tests/               # Unit tests
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

### Environment Variables
The following environment variables are required:

#### Database
- `ConnectionStrings:DefaultConnection` - SQL Server connection string

#### Authentication
- `Jwt:Key` - JWT encryption key

#### Caching
- `Redis:Configuration` - Redis connection settings

#### PayPal Configuration (Required)
- `PayPal:ClientId` - Your PayPal Sandbox API client ID
- `PayPal:ClientSecret` - Your PayPal Sandbox API secret key

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Run tests to ensure everything works
5. Commit your changes (`git commit -m 'Add some amazing feature'`)
6. Push to the branch (`git push origin feature/amazing-feature`)
7. Open a Pull Request

## 📄 License

This project is licensed under the [MIT License](LICENSE).

## 📞 Support & Contact

For support, questions, or feature requests:
- 📧 Email: your.email@example.com
- 📝 [Open an Issue](https://github.com/yourusername/TaleOn_BackEnd/issues)
- 💬 Join our [Discord Server](https://discord.gg/your-invite-link)

---

<div align="center">
  Made with ❤️ by TaleOn Team
</div>


### 💳 PayPal Integration (Sandbox Only)
- Secure payment processing via PayPal Sandbox
- Basic transaction creation and capture
- Payment status tracking in database

### ⚡ Performance
- Redis caching system
- Fast data loading
- Efficient request handling

### 📱 API Features
- Interactive documentation with Swagger
- Full RESTful API support
- Detailed API documentation with Scalar

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



## 📁 Project Structure

```
TaleOn_BackEnd/
├── TaleOn/              # Main API project
├── AccessData/          # Data access layer
├── Models/              # Data models and DTOs
├── TaleOn.Services/     # Business logic layer
└── Tests/               # Unit tests
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

### Environment Variables
The following environment variables are required:

#### Database
- `ConnectionStrings:DefaultConnection` - SQL Server connection string

#### Authentication
- `Jwt:Key` - JWT encryption key

#### Caching
- `Redis:Configuration` - Redis connection settings

#### PayPal Configuration (Required)
- `PayPal:ClientId` - Your PayPal Sandbox API client ID
- `PayPal:ClientSecret` - Your PayPal Sandbox API secret key

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Run tests to ensure everything works
5. Commit your changes (`git commit -m 'Add some amazing feature'`)
6. Push to the branch (`git push origin feature/amazing-feature`)
7. Open a Pull Request

## 📄 License

This project is licensed under the [MIT License](LICENSE).

## 📞 Support & Contact

For support, questions, or feature requests:
- 📧 Email: your.email@example.com
- 📝 [Open an Issue](https://github.com/yourusername/TaleOn_BackEnd/issues)
- 💬 Join our [Discord Server](https://discord.gg/your-invite-link)

---

<div align="center">
  Made with ❤️ by TaleOn Team
</div>
