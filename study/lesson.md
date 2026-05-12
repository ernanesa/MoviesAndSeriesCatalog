# 🎬 MoviesAndSeriesCatalog — Aula Completa

> Mentoria full-stack: .NET 10 + Dapper + React 19 + TypeScript 6 + Vite 7 + Aspire

---

## 📋 Índice

1. [Fase 1 — Fundação do Backend](#-fase-1--fundação-do-backend)
2. [Fase 2 — Modelagem do Domínio](#-fase-2--modelagem-do-domínio)
3. [Fase 3 — Repositórios e Endpoints](#-fase-3--repositórios-e-endpoints)
4. [Fase 4 — Frontend com React](#-fase-4--frontend-com-react)
5. [Fase 5 — Screens e Integração](#-fase-5--screens-e-integração)
6. [Fase 6 — Testes Automatizados](#-fase-6--testes-automatizados)
7. [Fase 7 — Cloud-Native com Aspire](#-fase-7--cloud-native-com-aspire)
8. [Mapa de Conceitos](#-mapa-de-conceitos)

---

## 🔴 Fase 1 — Fundação do Backend

### Conceito: Arquitetura em Camadas

Organizamos o código em 4 camadas principais:

```
┌──────────────┐
│   Endpoints   │  ← Garçom (recebe pedidos, entrega respostas)
├──────────────┤
│    Domain     │  ← Receita (regras de negócio, modelos puros)
├──────────────┤
│ Infrastructure│  ← Despensa (acesso a dados, banco)
├──────────────┤
│  Extensions   │  ← Organizador (configuração do DI)
└──────────────┘
```

**Regra de ouro:** Cada camada só conhece a camada imediatamente abaixo. `Domain` não sabe de `Infrastructure` nem de `Endpoints`.

### Conceito: Estrutura de Diretórios

```
src/MoviesAndSeriesCatalog.Api/
├── Domain/Models/           # Title.cs, Genre.cs, TitleType.cs
├── Infrastructure/
│   ├── Data/                # DbConnectionFactory, DatabaseInitializer
│   └── Repositories/        # IGenreRepository, GenreRepository, etc.
├── Endpoints/               # GenreEndpoints, TitleEndpoints
└── Extensions/              # ServiceCollectionExtensions
```

### Conceito: Dapper vs Entity Framework Core

| Característica | Dapper | EF Core |
|----------------|--------|---------|
| Abordagem | **SQL-first** — você escreve o SQL | **Code-first** — o EF gera o SQL |
| Performance | ⚡ Quase tão rápido quanto ADO.NET puro | 🐢 Mais lento (gera SQL, tracking) |
| Controle | Total sobre a query | Menos controle |
| Curva | Baixa (só precisa saber SQL) | Média (LINQ, tracking, migrations) |
| Factory | Você cria (`DbConnectionFactory`) | Embutida (`AddDbContext` já é uma factory) |

### Conceito: DbConnectionFactory (Factory Pattern)

```csharp
public class DbConnectionFactory(string connectionString)
{
    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(connectionString);
    }
}
```

**Por que usar:** Centraliza a criação de conexões. Se mudar de SQLite para PostgreSQL, muda **um** lugar.

### Conceito: DI Container (Singleton vs Scoped vs Transient)

| Ciclo de Vida | Analogia | Uso |
|--------------|----------|-----|
| **Singleton** 🏛️ | Uma estátua na praça — todos veem a mesma | `DbConnectionFactory` (sem estado) |
| **Scoped** 📞 | Uma ligação — cada requisição tem sua conexão | Repositórios (1 por requisição HTTP) |
| **Transient** 🥤 | Copo descartável — novo toda vez | Services leves sem estado |

### Arquivos Criados

- [`src/MoviesAndSeriesCatalog.Api/Domain/Models/Genre.cs`](src/MoviesAndSeriesCatalog.Api/Domain/Models/Genre.cs)
- [`src/MoviesAndSeriesCatalog.Api/Domain/Models/TitleType.cs`](src/MoviesAndSeriesCatalog.Api/Domain/Models/TitleType.cs)
- [`src/MoviesAndSeriesCatalog.Api/Domain/Models/Title.cs`](src/MoviesAndSeriesCatalog.Api/Domain/Models/Title.cs)
- [`src/MoviesAndSeriesCatalog.Api/Infrastructure/Data/DbConnectionFactory.cs`](src/MoviesAndSeriesCatalog.Api/Infrastructure/Data/DbConnectionFactory.cs)
- [`src/MoviesAndSeriesCatalog.Api/Infrastructure/Data/DatabaseInitializer.cs`](src/MoviesAndSeriesCatalog.Api/Infrastructure/Data/DatabaseInitializer.cs)
- [`src/MoviesAndSeriesCatalog.Api/Extensions/ServiceCollectionExtensions.cs`](src/MoviesAndSeriesCatalog.Api/Extensions/ServiceCollectionExtensions.cs)
- [`src/MoviesAndSeriesCatalog.Api/Program.cs`](src/MoviesAndSeriesCatalog.Api/Program.cs)

---

## 🟠 Fase 2 — Modelagem do Domínio

### Conceito: Record vs Class

| Característica | `class` | `record` |
|----------------|---------|----------|
| Igualdade | Por referência (endereço) | **Por valor** (campos iguais = objetos iguais) |
| Mutabilidade | Mutável por padrão | **Imutável** por padrão |
| Uso típico | Objetos com comportamento (services) | **Dados puros** (models, DTOs) |
| `ToString()` | Namespace.ClassName | Mostra todos os campos formatados |

**Regra prática:** Se a classe só carrega dados (como nossos models), use `record`.

### Conceito: Primary Constructors (C# 12/14)

```csharp
// Antes (C# < 12)
public class Genre
{
    public Guid Id { get; }
    public string Name { get; }
    public Genre(Guid id, string name) { Id = id; Name = name; }
}

// Depois (C# 12+)
public record Genre(Guid Id, string Name);
```

### Conceito: Normalização de Banco (N:N)

Para modelar o relacionamento "um título pode ter vários gêneros":

```
Titles ──< TitleGenres >── Genres
  id        titleId         id
  name      genreId         name
```

**Por que 3 tabelas?** Para evitar duplicação e permitir consultas eficientes.

### SQL Schema

```sql
CREATE TABLE Genres (Id TEXT PRIMARY KEY, Name TEXT NOT NULL UNIQUE);
CREATE TABLE Titles (Id TEXT PRIMARY KEY, Name TEXT, Synopsis TEXT, ReleaseYear INTEGER, Type INTEGER);
CREATE TABLE TitleGenres (TitleId TEXT, GenreId TEXT, PRIMARY KEY (TitleId, GenreId));
```

### Arquivos Criados

- [`src/MoviesAndSeriesCatalog.Api/Infrastructure/Database/001_CreateTables.sql`](src/MoviesAndSeriesCatalog.Api/Infrastructure/Database/001_CreateTables.sql)
- [`src/MoviesAndSeriesCatalog.Api/Infrastructure/Database/002_SeedData.sql`](src/MoviesAndSeriesCatalog.Api/Infrastructure/Database/002_SeedData.sql)

---

## 🟡 Fase 3 — Repositórios e Endpoints

### Conceito: Repository Pattern

```
Interface (contrato): "O que o repositório faz"
Implementação: "Como ele faz" (SQL + Dapper)
```

```csharp
// Interface — o cardápio
public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAllAsync();
}

// Implementação — a cozinha
public class GenreRepository(DbConnectionFactory factory) : IGenreRepository
{
    public async Task<IEnumerable<Genre>> GetAllAsync()
    {
        using var conn = factory.CreateConnection();
        conn.Open();
        return await conn.QueryAsync<Genre>("SELECT * FROM Genres");
    }
}
```

### Conceito: Multi-Mapping no Dapper

Para montar um objeto `Title` com sua `List<Genre>` a partir de JOIN:

```csharp
var titleDictionary = new Dictionary<Guid, Title>();

await connection.QueryAsync<Title, Genre, Title>(
    sql,
    (title, genre) => {
        if (!titleDictionary.TryGetValue(title.Id, out var existing))
        {
            existing = title with { Genres = [] };
            titleDictionary.Add(title.Id, existing);
        }
        if (genre is not null) existing.Genres.Add(genre);
        return existing;
    },
    splitOn: "Id");
```

### Conceito: Transações

```csharp
using var transaction = connection.BeginTransaction();
// INSERT INTO Titles
// INSERT INTO TitleGenres (vários)
transaction.Commit();
// Se algo falhar, tudo é desfeito (ROLLBACK automático)
```

### Conceito: Minimal API + TypedResults

```csharp
var group = app.MapGroup("/api/v1/titles");

group.MapGet("/", async (ITitleRepository repo) =>
{
    var titles = await repo.GetAllAsync();
    return TypedResults.Ok(titles);  // HTTP 200 com tipo seguro
});

group.MapGet("/{id:guid}", async (Guid id, ITitleRepository repo) =>
{
    var title = await repo.GetByIdAsync(id);
    return title is not null
        ? TypedResults.Ok(title)      // HTTP 200
        : TypedResults.NotFound();    // HTTP 404
});
```

### Endpoints Criados

| Método | Rota | Função |
|--------|------|--------|
| `GET` | `/api/v1/genres` | Listar todos os gêneros |
| `GET` | `/api/v1/titles` | Listar títulos (com filtros opcionais) |
| `GET` | `/api/v1/titles/{id}` | Detalhes de um título |
| `POST` | `/api/v1/titles` | Criar novo título |
| `PUT` | `/api/v1/titles/{id}` | Atualizar título |
| `DELETE` | `/api/v1/titles/{id}` | Excluir título |

### Arquivos Criados

- [`src/MoviesAndSeriesCatalog.Api/Infrastructure/Repositories/IGenreRepository.cs`](src/MoviesAndSeriesCatalog.Api/Infrastructure/Repositories/IGenreRepository.cs)
- [`src/MoviesAndSeriesCatalog.Api/Infrastructure/Repositories/GenreRepository.cs`](src/MoviesAndSeriesCatalog.Api/Infrastructure/Repositories/GenreRepository.cs)
- [`src/MoviesAndSeriesCatalog.Api/Infrastructure/Repositories/ITitleRepository.cs`](src/MoviesAndSeriesCatalog.Api/Infrastructure/Repositories/ITitleRepository.cs)
- [`src/MoviesAndSeriesCatalog.Api/Infrastructure/Repositories/TitleRepository.cs`](src/MoviesAndSeriesCatalog.Api/Infrastructure/Repositories/TitleRepository.cs)
- [`src/MoviesAndSeriesCatalog.Api/Endpoints/GenreEndpoints.cs`](src/MoviesAndSeriesCatalog.Api/Endpoints/GenreEndpoints.cs)
- [`src/MoviesAndSeriesCatalog.Api/Endpoints/TitleEndpoints.cs`](src/MoviesAndSeriesCatalog.Api/Endpoints/TitleEndpoints.cs)

---

## 🟢 Fase 4 — Frontend com React

### Conceito: Vite vs CRA

| Característica | CRA (Webpack) | Vite |
|----------------|---------------|------|
| Start do servidor | 30-60s | **~1s** |
| Hot reload | 2-5s | **< 50ms** |
| Build | 60-120s | **~10s** |

### Conceito: Vite Proxy (CORS)

```typescript
// vite.config.ts
export default defineConfig({
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:5001',
        changeOrigin: true,
      },
    },
  },
});
```

O proxy redireciona chamadas de `/api/*` do frontend para o backend, evitando erros de CORS.

### Conceito: Tipos Compartilhados (TypeScript ↔ C#)

```typescript
// TypeScript
export interface Genre {
    id: string;        // C#: Guid → string no JSON
    name: string;
}
export interface Title {
    id: string;
    name: string;
    synopsis: string | null;  // C#: string?
    releaseYear: number;      // C#: int
    type: 0 | 1;              // C#: TitleType enum → 0 ou 1
    genres: Genre[];
}
```

### Conceito: useEffect

```typescript
useEffect(() => {
    api.getTitles().then(data => setTitles(data));
}, []); // Array vazio = executa uma vez na montagem
```

**Mental Model:** `useEffect` é um alarme programado. O array de dependências diz **quando** disparar o alarme:
- `[]` → uma vez (montagem)
- `[searchTerm]` → toda vez que `searchTerm` mudar

### Conceito: Props e Composição

```tsx
interface TitleCardProps {
    title: Title;
}

export function TitleCard({ title }: TitleCardProps) {
    // ...
}
```

Props são os **ingredientes** de um componente. TypeScript valida se você passou todos.

### Arquivos Criados

- [`src/MoviesAndSeriesCatalog.Client/src/types/index.ts`](src/MoviesAndSeriesCatalog.Client/src/types/index.ts)
- [`src/MoviesAndSeriesCatalog.Client/src/services/api.ts`](src/MoviesAndSeriesCatalog.Client/src/services/api.ts)
- [`src/MoviesAndSeriesCatalog.Client/src/components/TitleCard.tsx`](src/MoviesAndSeriesCatalog.Client/src/components/TitleCard.tsx)
- [`src/MoviesAndSeriesCatalog.Client/src/pages/Home.tsx`](src/MoviesAndSeriesCatalog.Client/src/pages/Home.tsx)

---

## 🔵 Fase 5 — Screens e Integração

### Conceito: Formulários Controlados

```tsx
const [formData, setFormData] = useState({
    name: '',
    synopsis: '',
    releaseYear: 2026,
    type: 0,
    selectedGenreIds: [] as string[],
});

const handleChange = (field: string, value: string | number) => {
    setFormData(prev => ({ ...prev, [field]: value }));
};
```

**Fluxo:** Usuário digita → `onChange` → `setState` → React re-renderiza → input mostra novo valor.

### Conceito: Rotas Dinâmicas (useParams)

```tsx
// App.tsx
<Route path="/titles/:id" element={<Details />} />

// Details.tsx
const { id } = useParams<{ id: string }>(); // Extrai :id da URL
```

### Conceito: Navegação Programática (useNavigate)

```tsx
const navigate = useNavigate();

await api.deleteTitle(id);
navigate('/', { replace: true }); // Volta pra Home, sem criar histórico
```

**Analogia:** `useNavigate` é um controle remoto — você muda de canal a qualquer momento.

### Arquivos Criados

- [`src/MoviesAndSeriesCatalog.Client/src/pages/Register.tsx`](src/MoviesAndSeriesCatalog.Client/src/pages/Register.tsx)
- [`src/MoviesAndSeriesCatalog.Client/src/pages/Details.tsx`](src/MoviesAndSeriesCatalog.Client/src/pages/Details.tsx)

---

## 🧪 Fase 6 — Testes Automatizados

### Conceito: Pirâmide de Testes

```
         ╱╲
        ╱  ╲        E2E (Playwright) — fluxos completos
       ╱────╲
      ╱      ╲      Integration — endpoints + banco real
     ╱────────╲
    ╱          ╲    Unit — lógica pura (instantâneos)
```

### Conceito: WebApplicationFactory

```csharp
public class CustomWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly string _dbPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.db");

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("ConnectionStrings:DefaultConnection", $"Data Source={_dbPath}");
    }
}
```

**O que faz:** Sobe a aplicação em memória para testes, com banco SQLite temporário e isolado.

### Conceito: Padrão AAA (Arrange-Act-Assert)

```csharp
[Fact]
public async Task GetGenres_ReturnsAllGenres()
{
    // ARRANGE
    var client = new CustomWebApplicationFactory().CreateClient();

    // ACT
    var response = await client.GetAsync("/api/v1/genres");

    // ASSERT
    response.StatusCode.Should().Be(HttpStatusCode.OK);
}
```

### Conceito: Fact vs Theory (xUnit)

| Atributo | Uso |
|----------|-----|
| `[Fact]` | Teste simples, sem parâmetros |
| `[Theory]` | Teste parametrizado (roda com vários dados) |

### Conceito: Vitest vs Jest

| Característica | Jest | Vitest |
|----------------|------|--------|
| Velocidade | Lento | ⚡ Instantâneo (reusa pipeline do Vite) |
| Configuração | Complexa | Zero config |
| API | Própria | **Compatível com Jest** |

### Conceito: Testando Componentes React

```tsx
it('deve exibir o nome do título', () => {
    render(<MemoryRouter><TitleCard title={mockTitle} /></MemoryRouter>);
    expect(screen.getByText('Inception')).toBeInTheDocument();
});
```

**O que testar:** Renderização correta de dados, comportamento ao clicar, estados de loading/erro/vazio.
**O que NÃO testar:** Estilos CSS, implementação interna (useState/useEffect), bibliotecas de terceiros.

### Testes Criados (14 no total)

**Backend (7 testes — xUnit):**
- `GetGenres_ReturnsAllGenres`
- `GetTitles_ReturnsAllTitles`
- `GetTitleById_WithValidId_ReturnsTitle`
- `GetTitleById_WithInvalidId_ReturnsNotFound`
- `CreateTitle_ReturnsCreated`
- `DeleteTitle_WithValidId_ReturnsNoContent`
- `DeleteTitle_WithInvalidId_ReturnsNotFound`

**Frontend (7 testes — Vitest):**
- `TitleCard` exibe nome, ano, tipo, gêneros, sinopse
- `TitleCard` não exibe sinopse quando null
- `TitleCard` navega para detalhes ao clicar

### Arquivos Criados

- [`tests/MoviesAndSeriesCatalog.Tests/CustomWebApplicationFactory.cs`](tests/MoviesAndSeriesCatalog.Tests/CustomWebApplicationFactory.cs)
- [`tests/MoviesAndSeriesCatalog.Tests/GenreEndpointsTests.cs`](tests/MoviesAndSeriesCatalog.Tests/GenreEndpointsTests.cs)
- [`tests/MoviesAndSeriesCatalog.Tests/TitleEndpointsTests.cs`](tests/MoviesAndSeriesCatalog.Tests/TitleEndpointsTests.cs)
- [`src/MoviesAndSeriesCatalog.Client/src/components/TitleCard.test.tsx`](src/MoviesAndSeriesCatalog.Client/src/components/TitleCard.test.tsx)
- [`src/MoviesAndSeriesCatalog.Client/src/test/setup.ts`](src/MoviesAndSeriesCatalog.Client/src/test/setup.ts)

---

## 🚀 Fase 7 — Cloud-Native com Aspire

### Conceito: O que é .NET Aspire?

Aspire é um **orquestrador** que:
1. **Sobe tudo** com um único comando (`dotnet run` no AppHost)
2. **Gerencia ciclo de vida** — ordem de inicialização, reinicialização
3. **Dashboard unificado** — logs, traces, métricas, health checks num só lugar
4. **Service Discovery** — Injeta automaticamente URLs entre serviços

**Mental Model:** Aspire é o **maestro de uma orquestra**. Cada serviço (músico) toca seu instrumento, e o maestro (AppHost) coordena o timing e a harmonia.

### Conceito: ServiceDefaults

Projeto compartilhado que configura automaticamente:

| Funcionalidade | O que faz |
|----------------|-----------|
| **OpenTelemetry** | Coleta traces, metrics e logs de cada requisição |
| **Health Checks** | Endpoints `GET /health` e `GET /alive` |
| **Exception Handling** | Tratamento padronizado de erros |

### Conceito: Service Discovery

```csharp
// AppHost.cs
var api = builder.AddProject<Projects.MoviesAndSeriesCatalog_Api>("api");
var frontend = builder.AddNpmApp("frontend", "../src/MoviesAndSeriesCatalog.Client")
    .WithReference(api);  // Injeta a URL da API automaticamente
```

O Aspire gera a variável de ambiente `services__api__http__0` com a URL correta — sem configuração manual.

### Arquivos Criados

- [`MoviesAndSeriesCatalog.AppHost/AppHost.cs`](MoviesAndSeriesCatalog.AppHost/AppHost.cs)
- [`src/MoviesAndSeriesCatalog.ServiceDefaults/Extensions.cs`](src/MoviesAndSeriesCatalog.ServiceDefaults/Extensions.cs)

---

## 📚 Mapa de Conceitos

| # | Conceito | Fase | Componente |
|---|----------|------|------------|
| 1 | Arquitetura em camadas | 1 | Domain / Infra / Endpoints |
| 2 | Primary Constructors (C# 14) | 1 | `record Genre(Guid Id, string Name)` |
| 3 | Record vs Class | 2 | `record` para dados, `class` para comportamento |
| 4 | Factory Pattern | 1 | `DbConnectionFactory` |
| 5 | DI Container (Singleton/Scoped/Transient) | 1 | `AddSingleton`, `AddScoped` |
| 6 | Repository Pattern | 3 | Interface + Implementação |
| 7 | Dapper Multi-Mapping | 3 | `QueryAsync<T1, T2, TRet>` |
| 8 | Transações SQL | 3 | `BeginTransaction()` + `Commit()` |
| 9 | Normalização N:N | 2 | Tabela `TitleGenres` |
| 10 | Minimal API + TypedResults | 3 | `MapGroup`, `TypedResults.Ok` |
| 11 | Vite + Proxy | 4 | `vite.config.ts` proxy `/api` |
| 12 | TypeScript Strict | 4 | `type`, `interface`, `string \| null` |
| 13 | Props e Composição (React) | 4 | `TitleCard({ title }: Props)` |
| 14 | useEffect | 4 | Estado + ciclo de vida |
| 15 | Formulários Controlados | 5 | `value` + `onChange` |
| 16 | useParams (rotas dinâmicas) | 5 | `:id` na URL |
| 17 | useNavigate | 5 | Navegação programática |
| 18 | WebApplicationFactory | 6 | Testes com app em memória |
| 19 | Padrão AAA | 6 | Arrange-Act-Assert |
| 20 | Vitest + React Testing Library | 6 | Testes de componente |
| 21 | .NET Aspire Orchestration | 7 | AppHost multi-serviço |
| 22 | OpenTelemetry | 7 | Traces, metrics, logs |
| 23 | Service Discovery | 7 | `WithReference(api)` |
| 24 | Dapper vs EF Core | 1 | Factory explícita vs embutida |

---

## 🛠️ Comandos Úteis

```bash
# === Backend ===
# Compilar
dotnet build src/MoviesAndSeriesCatalog.Api/MoviesAndSeriesCatalog.Api.csproj

# Executar API
dotnet run --project src/MoviesAndSeriesCatalog.Api/MoviesAndSeriesCatalog.Api.csproj

# === Frontend ===
# Instalar dependências
cd src/MoviesAndSeriesCatalog.Client && npm install

# Executar em dev
cd src/MoviesAndSeriesCatalog.Client && npm run dev

# === Tudo junto (Aspire) ===
dotnet run --project MoviesAndSeriesCatalog.AppHost/MoviesAndSeriesCatalog.AppHost.csproj

# === Testes ===
# Backend
dotnet test tests/MoviesAndSeriesCatalog.Tests/MoviesAndSeriesCatalog.Tests.csproj

# Frontend
cd src/MoviesAndSeriesCatalog.Client && npm test

# Adicionar pacotes NuGet
dotnet add src/MoviesAndSeriesCatalog.Api/MoviesAndSeriesCatalog.Api.csproj package Dapper

# Adicionar referência entre projetos
dotnet add tests/MoviesAndSeriesCatalog.Tests/MoviesAndSeriesCatalog.Tests.csproj reference src/MoviesAndSeriesCatalog.Api/MoviesAndSeriesCatalog.Api.csproj
```
