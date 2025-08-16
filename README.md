# 🏢 Smart Room Scheduler

[![GitHub stars](https://img.shields.io/github/stars/eh3p/SmartRoomScheduler?style=social)](https://github.com/eh3p/SmartRoomScheduler/stargazers)
[![License: MIT](https://img.shields.io/badge/License-MIT-green)](LICENSE)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Ehab%20Ashraf-blue?logo=linkedin)](https://www.linkedin.com/in/ehab-ashraf-9a43a9283/)
[![Email](https://img.shields.io/badge/Email-ehabashraf1667@gmail.com-red?logo=gmail)](mailto:ehabashraf1667@gmail.com)

---

**Smart Room Scheduler** is a full-stack application to manage and reserve rooms efficiently.  
It features a responsive React frontend with a calendar view, and a robust ASP.NET Core backend with SQL Server integration. Fully Docker-ready for cross-platform deployment.

**Tech Stack:**

- Frontend: React 18, Vite, TypeScript, MUI, FullCalendar  
- Backend: ASP.NET Core Web API, Entity Framework Core  
- Database: SQL Server (EF Core Migrations & Seeding)  
- Real-time Updates: SignalR  
- DevOps: Docker & Docker Compose  

**Features:**

- User authentication & role management (Admin, Staff, Student)  
- Create, view, and manage room reservations  
- Interactive calendar for room bookings  
- Notifications for upcoming reservations  
- Docker-ready setup for quick deployment  
- Sample seed data included for fast testing  

**Quick Start (Docker recommended):**

```bash
docker compose up --build
