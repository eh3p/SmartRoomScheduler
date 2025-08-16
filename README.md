# Smart Room Scheduler (Docker-ready)

## What is this?
A clean starter of the project we discussed: ASP.NET Core Web API + SQL Server + React (Vite) + Docker.

## Quick start (Docker)
```bash
docker compose up --build
```
Then open:
- API Swagger: http://localhost:5212/swagger
- Frontend:     http://localhost:5173

## Local (no Docker)
Backend:
```bash
cd backend/SmartRoomScheduler.Api
dotnet restore
dotnet ef database update
dotnet run
```
Frontend:
```bash
cd frontend
npm install
npm run dev
```
(If needed) create `.env` from `.env.example` to point the API: `VITE_API_BASE=http://localhost:5212`.

## Notes
- We removed the broken `react-full-calendar` and replaced it with official `@fullcalendar/*` packages.
- Connection string for Docker is injected via env var to point to the `db` service.
- On first run the API auto-applies EF migrations and seeds a few rooms.
