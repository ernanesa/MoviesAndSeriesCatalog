# 🎯 Checkpoints — MoviesAndSeriesCatalog

> Checklist de aprendizado. Marque cada checkpoint conforme dominar o conceito.

---

## 🔴 Fase 1 — Fundação do Backend

- [x] **1.1** Entendo o que é arquitetura em camadas (Domain / Infrastructure / Endpoints) e por que separar
- [x] **1.2** Sei criar pastas organizadas dentro de um projeto .NET
- [x] **1.3** Sei instalar pacotes NuGet via `dotnet add package`
- [x] **1.4** Compreendo a diferença entre Dapper (SQL-first) e EF Core (Code-first)
- [x] **1.5** Sei criar uma `DbConnectionFactory` usando Primary Constructors (C# 14)
- [x] **1.6** Entendo o que é DI Container e a diferença entre Singleton, Scoped e Transient
- [x] **1.7** Sei registrar serviços no DI Container com `AddSingleton`, `AddScoped`
- [x] **1.8** Consigo configurar um `Program.cs` limpo sem boilerplate

## 🟠 Fase 2 — Modelagem do Domínio

- [ ] **2.1** Entendo a diferença entre `record` e `class` e quando usar cada um
- [ ] **2.2** Sei criar records com Primary Constructors (`record Genre(Guid Id, string Name)`)
- [ ] **2.3** Compreendo o que é um enum (`TitleType`) e como serializar para INTEGER
- [ ] **2.4** Entendo normalização de banco e relacionamentos N:N
- [ ] **2.5** Sei escrever scripts SQL com CREATE TABLE, FOREIGN KEY e INDEX
- [ ] **2.6** Sei criar seed data com INSERT OR IGNORE

## 🟡 Fase 3 — Repositórios e Endpoints

- [ ] **3.1** Entendo o Repository Pattern (Interface + Implementação)
- [ ] **3.2** Sei usar Dapper para consultas simples (`QueryAsync<T>`)
- [ ] **3.3** Sei usar Dapper para multi-mapping com JOIN (`QueryAsync<T1, T2, TRet>`)
- [ ] **3.4** Entendo transações SQL (`BeginTransaction` + `Commit` + `Rollback`)
- [ ] **3.5** Sei criar endpoints com Minimal API (`MapGroup`, `MapGet`, `MapPost`)
- [ ] **3.6** Entendo `TypedResults` e seus tipos (`Ok`, `NotFound`, `Created`, `NoContent`)
- [ ] **3.7** Sei organizar endpoints em classes estáticas separadas
- [ ] **3.8** Entendo como o DI injeta repositórios nos endpoints

## 🟢 Fase 4 — Frontend com React

- [ ] **4.1** Sei criar um projeto Vite com React + TypeScript
- [ ] **4.2** Entendo o que é e como configurar um proxy no Vite
- [ ] **4.3** Sei criar interfaces TypeScript que espelham models C#
- [ ] **4.4** Entendo o conceito de Props em React (`interface ComponentProps`)
- [ ] **4.5** Sei usar `useEffect` para buscar dados na montagem do componente
- [ ] **4.6** Entendo o fluxo: efeito → API → setState → re-render
- [ ] **4.7** Sei criar um service layer com fetch tipado
- [ ] **4.8** Sei configurar React Router (BrowserRouter, Routes, Route, Link)

## 🔵 Fase 5 — Screens e Integração

- [ ] **5.1** Entendo formulários controlados (value + onChange + setState)
- [ ] **5.2** Sei gerenciar estado de formulário com um único objeto
- [ ] **5.3** Sei lidar com checkbox groups (toggle de seleção)
- [ ] **5.4** Entendo `useParams` para rotas dinâmicas (`/titles/:id`)
- [ ] **5.5** Entendo `useNavigate` para navegação programática
- [ ] **5.6** Sei fazer submit com try/catch/finally + loading state
- [ ] **5.7** Entendo `window.confirm` para confirmação de exclusão
- [ ] **5.8** Sei usar `e.preventDefault()` em formulários

## 🧪 Fase 6 — Testes Automatizados

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

## 🚀 Fase 7 — Cloud-Native com Aspire

- [ ] **7.1** Entendo o que é .NET Aspire e qual problema ele resolve
- [ ] **7.2** Sei criar um projeto ServiceDefaults
- [ ] **7.3** Sei configurar OpenTelemetry (traces, metrics, logs)
- [ ] **7.4** Sei configurar Health Checks
- [ ] **7.5** Entendo como o AppHost orquestra múltiplos serviços
- [ ] **7.6** Sei adicionar projetos ao AppHost (`AddProject`, `AddNpmApp`)
- [ ] **7.7** Entendo Service Discovery com `WithReference`
- [ ] **7.8** Sei executar o Aspire e usar o Dashboard

---

## 📊 Barra de Progresso

```
🔴 Fase 1: [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]   (0/8)
🟠 Fase 2: [ ] [ ] [ ] [ ] [ ] [ ]             (0/6)
🟡 Fase 3: [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]   (0/8)
🟢 Fase 4: [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]   (0/8)
🔵 Fase 5: [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]   (0/8)
🧪 Fase 6: [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ] (0/10)
🚀 Fase 7: [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]   (0/8)

Total: 0/56 checkpoints
```

> 💡 **Dica:** Preencha a barra de progresso manualmente conforme for revisando. Exemplo: `[x]` para concluído, `[-]` em andamento.
