# 📋 Kanban Board - MoviesAndSeriesCatalog

Welcome to your development dashboard. When finishing a card, mark the box with an `x` to track your progress (e.g., `[x]`).

---

## 🔴 Phase 1: Foundation & Setup (Critical Priority)
The base of everything. Without this, nothing runs.

- [x] **Card 1: Backend Initialization**
  - *Goal:* Create the project Solution and initialize the Minimal Web API with .NET 10.
  - *Acceptance Criteria:* Structured solution and Swagger/OpenAPI responding locally.

- [ ] **Card 2: Frontend Initialization**
  - *Goal:* Create the project using Vite + React 19 + TypeScript 6.
  - *Acceptance Criteria:* Frontend project rendering the Vite home page on the local port.

- [ ] **Card 3: Dapper & SQLite Setup**
  - *Goal:* Install Dapper packages and configure the SQLite connection factory.
  - *Acceptance Criteria:* Database connection service registered in DI and packages installed.

---

## 🟠 Phase 2: Domain and Database (High Priority)
Business rules and table structure.

- [ ] **Card 4: Entity Modeling (Domain)**
  - *Goal:* Create models in C# 14 (Titles and Genres).
  - *Acceptance Criteria:* Classes created, using *Primary Constructors* where it makes sense.

- [ ] **Card 5: Database Schema & Seed**
  - *Goal:* Create the physical SQLite database and run a SQL script to initialize tables.
  - *Acceptance Criteria:* Database created with `Titles` and `Genres` tables via raw SQL.

---

## 🟡 Phase 3: APIs and Backend Routing (Medium-High Priority)
Making the Backend talk to the outside world.

- [ ] **Card 6: Genre Routes (Read)**
  - *Goal:* Implement a `GET` endpoint to fetch genres.
  - *Acceptance Criteria:* Swagger call returning a list of genres with HTTP 200.

- [ ] **Card 7: Title Routes (Register and List)**
  - *Goal:* Implement `POST` and `GET` for `/api/v1/titles` using Minimal APIs + TypedResults.
  - *Acceptance Criteria:* Ability to register and list movies/series via Swagger.

- [ ] **Card 8: Title Routes (Update and Delete)**
  - *Goal:* Implement `PUT` and `DELETE` for `/api/v1/titles/{id}`.
  - *Acceptance Criteria:* Working endpoints with ID validation (HTTP 404 for not found).

---

## 🟢 Phase 4: Frontend Structure (Medium Priority)
Preparing the visual stage of the project.

- [ ] **Card 9: Frontend Routing**
  - *Goal:* Configure the routing library (e.g., React Router) with empty Home and Register pages.
  - *Acceptance Criteria:* Navigate URLs without browser refresh (SPA).

- [ ] **Card 10: Layout and Base UI**
  - *Goal:* Create Navbar, global CSS styles (modern), and typography (Inter/Roboto).
  - *Acceptance Criteria:* Pages having a basic responsive visual shell.

- [ ] **Card 11: API Integration (Services)**
  - *Goal:* Create services/classes in the frontend to perform secure typed `fetch` via TypeScript 6.
  - *Acceptance Criteria:* Request functions ready to be called in components.

---

## 🔵 Phase 5: Screens and Final Integration (Normal Priority)
Putting the pieces together.

- [ ] **Card 12: Main Screen (Catalog)**
  - *Goal:* Consume the Listing API and render beautiful Cards for each movie/series.
  - *Acceptance Criteria:* Screen populated with data from SQLite, no mocks.

- [ ] **Card 13: Registration Screen**
  - *Goal:* Clean and validated form to send data to the `POST` endpoint.
  - *Acceptance Criteria:* Fill form -> Submit -> Save to DB -> Redirect to Home.

- [ ] **Card 14: Details Screen**
  - *Goal:* Click on a Card from Home and see details (synopsis, year, etc.).
  - *Acceptance Criteria:* Exclusive page reading detailed data from the API (`GET /id`).

---

## 🧪 Phase 6: Quality and Testing (Medium Priority)
Ensuring the system works now and forever.

- [ ] **Card 15: Backend Test Setup**
  - *Goal:* Create xUnit project and configure `WebApplicationFactory`.
  - *Acceptance Criteria:* A "Smoke Test" passing (e.g., API responding 200).

- [ ] **Card 16: Integration Tests (CRUD)**
  - *Goal:* Test the Create, List, and Delete flows in the Backend.
  - *Acceptance Criteria:* Coverage of the main Minimal API routes.

- [ ] **Card 17: Frontend Test Setup (Vitest)**
  - *Goal:* Configure Vitest and React Testing Library in Vite.
  - *Acceptance Criteria:* `npm test` command running without errors.

- [ ] **Card 18: Component Tests**
  - *Goal:* Test `TitleCard` and the `Registration` form.
  - *Acceptance Criteria:* Ensure the UI reflects data and validations.

---

## 🚀 Fase 7: Cloud-Native & Observability (Bleeding Edge)
Bringing the project to 2026 production standards.

- [ ] **Card 19: .NET Aspire Orchestration**
  - *Goal:* Create `AppHost` and `ServiceDefaults` projects to orchestrate API and Client.
  - *Acceptance Criteria:* Running `AppHost` launches both API and Client with a unified dashboard.

- [ ] **Card 20: OpenTelemetry Setup**
  - *Goal:* Configure OTel in `.ServiceDefaults` and export traces to the Aspire Dashboard.
  - *Acceptance Criteria:* See real-time request traces in the dashboard when using the App.

