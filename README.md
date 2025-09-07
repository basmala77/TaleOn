# 🚀 TaleOn - Interactive Story Management System

## 📋 Table of Contents
- [Overview](#-overview)
- [Features](#-key-features)
- [Requirements](#-requirements)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [Technical Documentation](#-technical-documentation)
- [Contributing](#-contributing)

## 🌟 Overview

TaleOn is an integrated interactive story management system, specifically designed to provide a rich and smooth user experience. The system is built on a modern and scalable architecture using the latest .NET technologies.

## ✨ Key Features

### 🔒 Authentication System
- JWT-based authentication
- Email verification via OTP
- User roles and permissions management

### 💳 Payment System
- Integration with multiple payment gateways
- Transaction tracking
- Invoicing and payment notifications

### ⚡ Performance
- Redis caching system
- Fast data loading
- Efficient request handling

### 📱 API Features
- Interactive documentation with Swagger
- Full RESTful API support
- Detailed API documentation with Scalar

## ⚙️ Requirements

### Development Environment
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Databases
- SQL Server 2019+
- Redis Server

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
TaleOn_BackEnd/
├── TaleOn/              # Main API project
├── AccessData/          # Data access layer
├── Models/              # Data models and DTOs
├── TaleOn.Services/     # Business logic layer
└── Tests/               # Unit tests
```

## 📚 Technical Documentation

### API Endpoints
- `/api/AuthUser` - Authentication and user management
- `/api/Child` - Children accounts management
- `/api/Parent` - Parent accounts management
- `/api/Payment` - Payment processing

### Environment Variables
The following environment variables are required:
- `ConnectionStrings:DefaultConnection` - SQL Server connection string
- `Jwt:Key` - JWT encryption key
- `Redis:Configuration` - Redis connection settings
- `PayPal:ClientId` - PayPal API client ID
- `PayPal:ClientSecret` - PayPal API client secret

## 🤝 Contributing

1. Fork the repository
2. Create a new branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Commit your changes (`git commit -m 'Add some amazing feature'`)
5. Push to the branch (`git push origin feature/amazing-feature`)
6. Open a Pull Request

## 📄 License

This project is licensed under the [MIT License](LICENSE).

## 📞 Support

For any technical questions or issues, please open a new [issue](https://github.com/yourusername/TaleOn_BackEnd/issues).
# TaleOn_BackEnd
