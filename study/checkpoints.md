# 🎯 Checkpoints — MoviesAndSeriesCatalog

> Checklist de aprendizado. Marque cada checkpoint conforme dominar o conceito.
>
> **Última análise:** 16/05/2026 — Diagnóstico automático do código-fonte.

---

## 🔴 Fase 1 — Fundação do Backend ✅ (CONCLUÍDO)

- [x] **1.1** Entendo o que é arquitetura em camadas (Domain / Infrastructure / Endpoints) e por que separar
- [x] **1.2** Sei criar pastas organizadas dentro de um projeto .NET
- [x] **1.3** Sei instalar pacotes NuGet via `dotnet add package`
- [x] **1.4** Compreendo a diferença entre Dapper (SQL-first) e EF Core (Code-first)
- [x] **1.5** Sei criar uma `DbConnectionFactory` usando Primary Constructors (C# 14)
- [x] **1.6** Entendo o que é DI Container e a diferença entre Singleton, Scoped e Transient
- [x] **1.7** Sei registrar serviços no DI Container com `AddSingleton`, `AddScoped`
- [x] **1.8** Consigo configurar um `Program.cs` limpo sem boilerplate

> **Evidências no código:**
> - [`Program.cs`](src/MoviesAndSeriesCatalog.Api/Program.cs) — SlimBuilder, OpenAPI + Scalar configurados
> - [`ServiceCollectionExtensions.cs`](src/MoviesAndSeriesCatalog.Api/Extensions/ServiceCollectionExtensions.cs) — DI com `AddSingleton<DbConnectionFactory>`
> - [`DbConnectionFactory.cs`](src/MoviesAndSeriesCatalog.Api/Infrastructure/Data/DbConnectionFactory.cs) — Primary Constructor + Factory Pattern
> - [`MoviesAndSeriesCatalog.Api.csproj`](src/MoviesAndSeriesCatalog.Api/MoviesAndSeriesCatalog.Api.csproj) — Dapper, SQLite, Scalar instalados

---

## 🟠 Fase 2 — Modelagem do Domínio ⏳ (NÃO INICIADO)

- [x] **2.1** Entendo a diferença entre `record` e `class` e quando usar cada um
- [x] **2.2** Sei criar records com Primary Constructors (`record Genre(Guid Id, string Name)`)
- [x] **2.3** Compreendo o que é um enum (`TitleType`) e como serializar para INTEGER
- [ ] **2.4** Entendo normalização de banco e relacionamentos N:N
- [ ] **2.5** Sei escrever scripts SQL com CREATE TABLE, FOREIGN KEY e INDEX
- [ ] **2.6** Sei criar seed data com INSERT OR IGNORE

> **Status:** Nenhum arquivo de domínio foi criado ainda. Faltam:
> - `Domain/Models/Genre.cs`
> - `Domain/Models/Title.cs`
> - `Domain/Models/TitleType.cs`
> - `Infrastructure/Database/001_CreateTables.sql`
> - `Infrastructure/Database/002_SeedData.sql`

---

## 🟡 Fase 3 — Repositórios e Endpoints ⏳ (NÃO INICIADO)

- [ ] **3.1** Entendo o Repository Pattern (Interface + Implementação)
- [ ] **3.2** Sei usar Dapper para consultas simples (`QueryAsync<T>`)
- [ ] **3.3** Sei usar Dapper para multi-mapping com JOIN (`QueryAsync<T1, T2, TRet>`)
- [ ] **3.4** Entendo transações SQL (`BeginTransaction` + `Commit` + `Rollback`)
- [ ] **3.5** Sei criar endpoints com Minimal API (`MapGroup`, `MapGet`, `MapPost`)
- [ ] **3.6** Entendo `TypedResults` e seus tipos (`Ok`, `NotFound`, `Created`, `NoContent`)
- [ ] **3.7** Sei organizar endpoints em classes estáticas separadas
- [ ] **3.8** Entendo como o DI injeta repositórios nos endpoints

> **Status:** Nenhum repositório ou endpoint foi criado ainda. Faltam:
> - `Infrastructure/Repositories/IGenreRepository.cs`
> - `Infrastructure/Repositories/GenreRepository.cs`
> - `Infrastructure/Repositories/ITitleRepository.cs`
> - `Infrastructure/Repositories/TitleRepository.cs`
> - `Endpoints/GenreEndpoints.cs`
> - `Endpoints/TitleEndpoints.cs`

---

## 🟢 Fase 4 — Frontend com React ⏳ (NÃO INICIADO)

- [ ] **4.1** Sei criar um projeto Vite com React + TypeScript
- [ ] **4.2** Entendo o que é e como configurar um proxy no Vite
- [ ] **4.3** Sei criar interfaces TypeScript que espelham models C#
- [ ] **4.4** Entendo o conceito de Props em React (`interface ComponentProps`)
- [ ] **4.5** Sei usar `useEffect` para buscar dados na montagem do componente
- [ ] **4.6** Entendo o fluxo: efeito → API → setState → re-render
- [ ] **4.7** Sei criar um service layer com fetch tipado
- [ ] **4.8** Sei configurar React Router (BrowserRouter, Routes, Route, Link)

> **Status:** O diretório `src/MoviesAndSeriesCatalog.Client/` **não existe** no disco. Nada do frontend foi iniciado.

---

## 🔵 Fase 5 — Screens e Integração ⏳ (NÃO INICIADO)

- [ ] **5.1** Entendo formulários controlados (value + onChange + setState)
- [ ] **5.2** Sei gerenciar estado de formulário com um único objeto
- [ ] **5.3** Sei lidar com checkbox groups (toggle de seleção)
- [ ] **5.4** Entendo `useParams` para rotas dinâmicas (`/titles/:id`)
- [ ] **5.5** Entendo `useNavigate` para navegação programática
- [ ] **5.6** Sei fazer submit com try/catch/finally + loading state
- [ ] **5.7** Entendo `window.confirm` para confirmação de exclusão
- [ ] **5.8** Sei usar `e.preventDefault()` em formulários

> **Status:** Depende das Fases 2-4. Nada foi iniciado.

---

## 🧪 Fase 6 — Testes Automatizados ⏳ (NÃO INICIADO)

- [ ] **6.1** Entendo a pirâmide de testes (Unit → Integration → E2E)
- [ ] **6.2** Sei criar um projeto xUnit
- [ ] **6.3** Entendo `WebApplicationFactory` para testes de integração
- [ ] **6.4** Sei isolar o banco com SQLite temporário
- [ ] **6.5** Entendo o padrão AAA (Arrange-Act-Assert)
- [ ] **6.6** Sei usar FluentAssertions (`Should().Be()`)
- [ ] **6.7** Sei configurar Vitest no Vite
- [ ] **6.8** Entendo `jsdom` para simular o DOM em testes
- [ ] **6.9** Sei testar componentes React com `render` + `screen`
- [ ] **6.10** Sei testar renderização condicional com `queryByText`

> **Status:** O diretório `tests/` **não existe** no disco. Nada dos testes foi iniciado.

---

## 🚀 Fase 7 — Cloud-Native com Aspire ⏳ (EM ANDAMENTO)

- [x] **7.1** Entendo o que é .NET Aspire e qual problema ele resolve
- [ ] **7.2** Sei criar um projeto ServiceDefaults
- [ ] **7.3** Sei configurar OpenTelemetry (traces, metrics, logs)
- [ ] **7.4** Sei configurar Health Checks
- [ ] **7.5** Entendo como o AppHost orquestra múltiplos serviços
- [ ] **7.6** Sei adicionar projetos ao AppHost (`AddProject`, `AddNpmApp`)
- [ ] **7.7** Entendo Service Discovery com `WithReference`
- [ ] **7.8** Sei executar o Aspire e usar o Dashboard

> **Status:** O projeto [`MoviesAndSeriesCatalog.AppHost`](MoviesAndSeriesCatalog.AppHost/AppHost.cs) existe, mas é **apenas um esqueleto** — `builder.Build().Run()` sem nenhum serviço configurado. O projeto `ServiceDefaults` **não existe** no disco.

---

## 📊 Barra de Progresso

```
🔴 Fase 1: [x] [x] [x] [x] [x] [x] [x] [x]   (8/8) ✅
🟠 Fase 2: [ ] [ ] [ ] [ ] [ ] [ ]             (0/6)
🟡 Fase 3: [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]   (0/8)
🟢 Fase 4: [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]   (0/8)
🔵 Fase 5: [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]   (0/8)
🧪 Fase 6: [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ] (0/10)
🚀 Fase 7: [x] [ ] [ ] [ ] [ ] [ ] [ ] [ ]   (1/8)
```

**Total: 9/56 checkpoints**

---

## 📋 Diagnóstico da Implementação Real vs Planejada

| Item | Planejado | Real | Status |
|------|-----------|------|--------|
| Backend API | `src/MoviesAndSeriesCatalog.Api/` | ✅ Criado com Program.cs, DI, DbConnectionFactory | 🟡 Parcial |
| Domain Models | `Genre.cs`, `Title.cs`, `TitleType.cs` | ❌ Não existem | 🔴 Pendente |
| SQL Schema | Scripts .sql | ❌ Não existem | 🔴 Pendente |
| Repositories | 4 arquivos (interfaces + implementações) | ❌ Não existem | 🔴 Pendente |
| Endpoints | `GenreEndpoints.cs`, `TitleEndpoints.cs` | ❌ Não existem | 🔴 Pendente |
| Frontend Client | `src/MoviesAndSeriesCatalog.Client/` | ❌ Não existe | 🔴 Pendente |
| Tests | `tests/MoviesAndSeriesCatalog.Tests/` | ❌ Não existe | 🔴 Pendente |
| AppHost | `MoviesAndSeriesCatalog.AppHost/` | ✅ Esqueleto criado | 🟡 Parcial |
| ServiceDefaults | Projeto compartilhado | ❌ Não existe | 🔴 Pendente |

> 💡 **Próximo passo sugerido:** Começar pela **Fase 2 — Modelagem do Domínio**, que é o alicerce para todo o resto. Sem os modelos de domínio, não é possível criar repositórios, endpoints, ou o frontend.
