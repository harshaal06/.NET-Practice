using MySql.Data.MySqlClient;
using System.Data;

namespace ContactsApp.Infrastructure.Utils;

public class SqlHelper
{
    private readonly string _connectionString;

    public SqlHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }

    public async Task<int> ExecuteNonQueryAsync(string query, Dictionary<string, object>? parameters = null)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new MySqlCommand(query, connection);
        
        if (parameters != null)
        {
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }
        }

        return await command.ExecuteNonQueryAsync();
    }

    public async Task<List<T>> ExecuteReaderAsync<T>(string query, Func<MySqlDataReader, T> mapper, Dictionary<string, object>? parameters = null)
    {
        var results = new List<T>();

        using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new MySqlCommand(query, connection);
        
        if (parameters != null)
        {
            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }
        }

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            results.Add(mapper((MySqlDataReader)reader));
        }

        return results;
    }
}
