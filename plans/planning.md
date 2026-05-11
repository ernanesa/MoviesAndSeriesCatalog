# Project Planning: MoviesAndSeriesCatalog

## 🚀 Overview and Tech Stack
*   **Backend:** .NET 10, C# 14, Minimal APIs.
*   **Frontend:** React 19 with Vite 7, TypeScript 6.
*   **Database:** Dapper (Micro-ORM) with a Repository Pattern, using SQLite.
*   **Environment:** Node.js 26.
*   **Solution Structure:** `.slnx` file (modern and lean XML format).

## 📁 Proposed Directory Structure

```text
MoviesAndSeriesCatalog/
├── MoviesAndSeriesCatalog.slnx                 # New Visual Studio / .NET solution format
├── MoviesAndSeriesCatalog.AppHost/             # .NET Aspire Orchestrator (entry point)
├── MoviesAndSeriesCatalog.ServiceDefaults/     # Shared Aspire configurations (OTel, HealthChecks)
├── src/
│   ├── MoviesAndSeriesCatalog.Api/             # Backend .NET 10 Minimal API
│   │   ├── Domain/                    # Models (Title, Genre, TitleType)
│   │   ├── Infrastructure/            # Dapper Repositories, DB Connections
│   │   ├── Endpoints/                 # Route grouping (Minimal APIs)
│   │   ├── Extensions/                # Extensions for dependency injection
│   │   ├── Program.cs                 # Lean entrypoint
│   │   └── MoviesAndSeriesCatalog.Api.csproj
│   │
│   └── MoviesAndSeriesCatalog.Client/          # Frontend React 19 + TypeScript 6
│       ├── src/
│       │   ├── components/            # UI visual components
│       │   ├── hooks/                 # Custom React hooks
│       │   ├── pages/                 # Main screens (Home, Registration, Details)
│       │   ├── services/              # API Client (e.g., native fetch, Ky, or Axios)
│       │   ├── types/                 # Strict TS 6 interfaces
│       │   ├── App.tsx
│       │   └── main.tsx
│       ├── vite.config.ts
│       ├── package.json
│       └── tsconfig.json
└── tests/
    └── MoviesAndSeriesCatalog.Tests/           # Automated tests (xUnit)
```

## 🌐 Cloud-Native & Observability
*   **Orchestration:** .NET Aspire will manage the lifecycle of the API, Database, and Client, providing a centralized dashboard for logs, traces, and metrics.
*   **OpenTelemetry:** Native implementation of OTel for distributed tracing, helping monitor requests from the Client to the API and Database.
*   **Health Checks:** Standardized health probes for all services via `.ServiceDefaults`.

## 🛣️ Route Planning (REST API - Minimal APIs)

The API will use standard versioning (`/api/v1`) and make heavy use of `TypedResults` and `EndpointFilters`.

### 🎬 Titles (Movies and Series)
*   **`GET /api/v1/titles`**
    *   *Description:* Lists movies and series.
    *   *Query Params:* `search`, `type` (movie/series), `genreId`, `page`, `pageSize`.
*   **`GET /api/v1/titles/{id:guid}`**
    *   *Description:* Returns details for a specific title.
*   **`POST /api/v1/titles`**
    *   *Description:* Creates a new movie or series.
    *   *Body:* Title data (name, synopsis, year, type, genres).
*   **`PUT /api/v1/titles/{id:guid}`**
    *   *Description:* Updates all data for a title.
*   **`DELETE /api/v1/titles/{id:guid}`**
    *   *Description:* Removes a title from the catalog.

### 🎭 Genres
*   **`GET /api/v1/genres`**
    *   *Description:* Lists available genres for registration (Action, Comedy, Drama, etc.).

## 🌟 Modern Paradigms to be Used

### On the Backend (.NET 10 / C# 14)
*   **C# 14 Features:** Primary Constructors, Collection Expressions, enhanced pattern matching, and new ref struct improvements.
*   **Advanced Minimal APIs:** Use of Endpoint Groups, TypedResults, and native Endpoint Filters in .NET 10.
*   **Dapper & SQL-First:** Use of the Dapper micro-ORM for high-performance data access, leveraging raw SQL and efficient mapping to C# 14 records.
*   **Native AOT Compatibility:** Ensuring all data access logic is compatible with .NET 10 Native AOT for minimal startup time and memory footprint.

### On the Frontend (React 19 / TypeScript 6 / Vite 7)
*   **React 19:** Optimized rendering and state management using the latest hooks and Concurrent Mode features.
*   **TypeScript 6:** Strict typing with the latest features for type pattern matching and superior flow control.
*   **Vite 7 & Node 26:** Near-instant build times and native support for the latest V8 features.
