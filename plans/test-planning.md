# 🧪 Test Planning - MoviesAndSeriesCatalog

This document details the testing strategy to ensure the quality and stability of the Fullstack application.

## 🏗️ Strategy: Testing Pyramid

We will follow the testing pyramid to optimize execution time and coverage:
1. **Integration Tests (Backend):** 60% coverage.
2. **Component Tests (Frontend):** 30% coverage.
3. **E2E Tests (End-to-End):** 10% coverage.

---

## 🟢 Phase 1: Backend (Integration & Unit)
**Goal:** Validate persistence and business rules.

- **Tools:** xUnit, FluentAssertions, Microsoft.AspNetCore.Mvc.Testing.
- **Key Tests:**
    - `POST /api/v1/titles`: Validate creation with valid data and failure with invalid data.
    - `GET /api/v1/titles/{id}`: Validate object return and 404 error.
    - `DELETE /api/v1/titles/{id}`: Validate if the record is removed via raw SQL/Repository.
    - **Unit:** Validate SQL query strings or mapping logic within repositories.

## 🟡 Phase 2: Frontend (Components & UI)
**Goal:** Ensure the interface behaves as expected.

- **Tools:** Vitest, React Testing Library.
- **Key Tests:**
    - **TitleCard:** Check if it correctly displays the name, genre, and year.
    - **Home:** Test if it displays the "Empty Catalog" message when the API returns an empty list.
    - **TitleForm:** Verify if the submit button triggers the API call.
    - **SweetAlert2:** Ensure visual feedback is displayed.

## 🔵 Phase 3: E2E (Complete Flows)
**Goal:** Simulate the real user journey.

- **Tools:** Playwright.
- **Main Scenario:**
    1. Open Home.
    2. Navigate to Registration.
    3. Create a new Movie.
    4. Return to Home and check if the Movie appears in the list.
    5. Open Movie details and delete it.
    6. **Observability Check:** Verify if traces and logs for the entire flow are visible in the .NET Aspire Dashboard.


---

## 🛠️ Useful Commands
- Run backend tests: `dotnet test`
- Run frontend tests: `npm test`
- Run E2E tests: `npx playwright test`
