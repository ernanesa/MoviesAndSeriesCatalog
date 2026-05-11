# 🎬 Movies And Series Catalog - Your Home Cinema

![.NET Version](https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet)
![React Version](https://img.shields.io/badge/React-19-61DAFB?style=for-the-badge&logo=react)
![Dapper](https://img.shields.io/badge/Dapper-Micro--ORM-blue?style=for-the-badge)
![Aspire](https://img.shields.io/badge/.NET%20Aspire-Cloud--Native-green?style=for-the-badge)
![TypeScript](https://img.shields.io/badge/TypeScript-6-3178C6?style=for-the-badge&logo=typescript)

**Movies And Series Catalog** is a bleeding-edge Fullstack application designed to manage your personal catalog of movies and series. Built with a focus on extreme performance, native observability, and a Dark Mode interface.

---

## 🌟 Why This Stack? (2026 Standards)

- **Extreme Performance:** By using **Dapper** over traditional ORMs and optimizing for **Native AOT**, the backend achieves near-instant startup times and minimal memory footprint.
- **Native Observability:** Integrated with **OpenTelemetry** from day one, providing distributed tracing and real-time metrics via the **.NET Aspire Dashboard**.
- **Modern React:** Leveraging the **React 19 Compiler**, the frontend is faster than ever, with automatic optimizations that eliminate manual re-render management.

---

## 🚀 Key Features

- **⚡ High-Performance CRUD:** Lightning-fast management of your titles using raw SQL power.
- **📊 Real-time Dashboard:** Monitor your application's health, logs, and traces through the .NET Aspire orchestrator.
- **🎭 Premium UX:** A sleek, fluid interface with **SweetAlert2** and cinematic transitions.
- **📱 Ultra-Responsive:** Optimized for everything from mobile devices to 4K home theater screens.
- **🛡️ Type-Safe:** End-to-end type safety using **TypeScript 6** and **C# 14**.

---

## 🛠️ Technologies Used

### Backend
- **C# 14 / .NET 10** (Minimal APIs & Native AOT)
- **Dapper** (Micro-ORM for raw SQL performance)
- **.NET Aspire** (Cloud-native orchestration & dashboard)
- **OpenTelemetry** (Standardized distributed tracing)
- **SQLite** (Portable, high-performance local database)

### Frontend
- **React 19** (Vite 7 based build system)
- **TypeScript 6** (Strict typing and modern patterns)
- **CSS Variables** (Centralized Design System)
- **SweetAlert2** (Non-blocking visual feedback)

---

## 📦 How to Run

The easiest way to run the entire stack (API, Client, and Dashboard) is through the **Aspire Orchestrator**.

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js 26+](https://nodejs.org/)

### 1. Run Everything (Orchestrated)
```bash
# From the root directory
dotnet run --project MoviesAndSeriesCatalog.AppHost
```
This will launch the **Aspire Dashboard** at `http://localhost:18888`, where you can access the API, the Frontend, and all logs/traces.

### 2. Manual Development
If you prefer running them separately:

**Backend:**
```bash
cd src/MoviesAndSeriesCatalog.Api
dotnet run
```

**Frontend:**
```bash
cd src/MoviesAndSeriesCatalog.Client
npm install && npm run dev
```

---

## 🎨 Design System

The project follows a "Streaming Platform" aesthetic:

- **Primary Color:** Cyan (`#00d1b2`) - High visibility and modern feel.
- **Background:** Deep Navy (`#0f172a`) - Reduces eye strain and feels premium.
- **Surface:** Slate (`#1e293b`) - Subtle contrast for cards and modals.

---

## 🛡️ License

Developed for educational purposes as part of the **DIO - Decola Tech** challenge.

---

### Author
Developed with ❤️ by [Ernane Sa](https://github.com/ernanesa).
