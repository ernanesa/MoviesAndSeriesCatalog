using System.Data;
using Microsoft.Data.Sqlite;

namespace MoviesAndSeriesCatalog.Api.Infrastructure.Data;

public class DbConnectionFactory(string connectionString)
{
    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(connectionString);
    }
}