# 🏢 Smart Room Scheduler

[![GitHub stars](https://img.shields.io/github/stars/eh3p/SmartRoomScheduler?style=social)](https://github.com/eh3p/SmartRoomScheduler/stargazers)
[![License: MIT](https://img.shields.io/badge/License-MIT-green)](LICENSE)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Ehab%20Ashraf-blue?logo=linkedin)](https://www.linkedin.com/in/ehab-ashraf-9a43a9283/)
[![Email](https://img.shields.io/badge/Email-ehabashraf1667@gmail.com-red?logo=gmail)](mailto:ehabashraf1667@gmail.com)

---

**Smart Room Scheduler** is a **full-stack application** to manage and reserve rooms efficiently.  
It features a responsive **React frontend** with a calendar view, and a robust **ASP.NET Core backend** with SQL Server integration.  
Fully **Docker-ready** for cross-platform deployment.

---

## 🚀 Tech Stack

- **Frontend**: React 18, Vite, TypeScript, MUI, FullCalendar  
- **Backend**: ASP.NET Core Web API, Entity Framework Core  
- **Database**: SQL Server (EF Core Migrations & Seeding)  
- **Real-time Updates**: SignalR  
- **DevOps**: Docker & Docker Compose  

---

## 🌟 Features

- 🔑 User authentication & role management (`Admin`, `Staff`, `Student`)  
- 🏫 Create, view, and manage room reservations  
- 📅 Interactive calendar for room bookings  
- 🔔 Notifications for upcoming reservations  
- 🛠️ API auto-documented with **Swagger**  
- 📦 Docker-ready setup for quick deployment  
- 🧪 Sample seed data included for fast testing  

---

## ⚡ Quick Start (Docker Recommended)

```bash
# Clone the repository
git clone https://github.com/eh3p/SmartRoomScheduler.git
cd SmartRoomScheduler

# Run with Docker
docker compose up --build

````

---

## 🔧 Manual Setup

### Backend

```bash
cd backend/SmartRoomScheduler.Api

dotnet restore
dotnet ef database update
dotnet run
```

### Frontend

```bash
cd frontend

npm install
npm run dev
```

Frontend will start at: [http://localhost:5173](http://localhost:5173)

---

## 📖 API Endpoints

### 🔐 Auth

```http
POST /api/auth/register   # Register new user
POST /api/auth/login      # Login & get JWT
```

### 👤 Users

```http
GET    /api/users         # Get all users (Admin only)
GET    /api/users/{id}    # Get user by ID
DELETE /api/users/{id}    # Delete user (Admin only)
```

### 🏢 Rooms

```http
GET    /api/rooms         # Fetch all rooms
GET    /api/rooms/{id}    # Get room by ID
POST   /api/rooms         # Add new room (Admin only)
PUT    /api/rooms/{id}    # Update room details (Admin only)
DELETE /api/rooms/{id}    # Remove room (Admin only)
```

### 📅 Reservations

```http
GET    /api/reservations        # View all reservations
GET    /api/reservations/{id}   # Get reservation by ID
POST   /api/reservations        # Create reservation
PUT    /api/reservations/{id}   # Update reservation
DELETE /api/reservations/{id}   # Cancel reservation
```

## 📧 Contact

* 📩 **Gmail**: [ehabashraf1667@gmail.com](mailto:ehabashraf1667@gmail.com)
* 💼 **LinkedIn**: [Ehab Ashraf](https://www.linkedin.com/in/ehab-ashraf-9a43a9283/)
* 🐙 **GitHub**: [eh3p](https://github.com/eh3p)

```
```
