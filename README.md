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
| <img width="1080" height="1920" alt="Screenshot 2025-09-13 234723" src="https://github.com/user-attachments/assets/304ed929-2a58-41af-865d-fedf998cc61a" />
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
- Transaction history
- Sandbox environment for testing

### 📱 API Features
- Interactive documentation with Swagger
- Full RESTful API support
- JWT authentication
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
- `POST /api/Auth/forgot-password` - Password recovery  

### Parent Features
- `GET /api/Parent/profile` - Get parent profile  
- `PUT /api/Parent/update-profile` - Update parent profile  
- `GET /api/Parent/children` - Get all children  
- `POST /api/Parent/add-child` - Add a new child  

### Child Features
- `GET /api/Children` - Get child details  
- `POST /api/Children` - Create child profile  
- `PUT /api/Children/{id}` - Update child profile  
- `GET /api/Children/{id}/stories` - Get child's stories  

### Story Features
- `POST /api/Story/generate` - Generate new story  
- `GET /api/Story/{id}` - Get story details  
- `GET /api/Story/child/{childId}` - Get all stories for a child  
- `POST /api/Story/rate` - Rate a story  

### Payment Features
- `GET /api/Payment/token` - Get payment token  
- `POST /api/Payment/create-order` - Create payment order  
- `POST /api/Payment/capture` - Capture payment  
- `GET /api/Payment/history` - Get payment history  
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
