using System.Data;
using Dapper;
using Npgsql;
using Tarefas.Interfaces;
using Tarefas.Models;

namespace Tarefas.Repositories;

public class TaskRepository : ITaskRepository
{
    
    private readonly string _connectionString;

    public TaskRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }
    private IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
    
    public async Task AddTask(Item item)
    {
        using var connection = CreateConnection();
        const string query = "INSERT INTO item (titulo, descricao) VALUES (@titulo, @descricao)";
        await connection.ExecuteAsync(query, item);
    }
    
    public async Task<List<Item>> GetTasks()
    {
        using var connection = CreateConnection();
        const string query = "SELECT * FROM item";
        var items = await connection.QueryAsync<Item>(query);
        return [..items];
    }

    public async Task<Item> GetTask(int id)
    {
        using var connection = CreateConnection();
        const string query = "SELECT * FROM item WHERE id = @id";
        return await connection.QueryFirstOrDefaultAsync<Item>(query, new { id });
    }

    public async Task UpdateTask(Item item)
    {
        using var connection = CreateConnection();
        const string query = "UPDATE item SET titulo = @titulo, descricao = @descricao WHERE id = @id";
        await connection.ExecuteAsync(query, item);
    }

    public async Task DeleteTask(int id)
    {
        using var connection = CreateConnection();
        const string query = "DELETE FROM item WHERE id = @id";
        await connection.ExecuteAsync(query, new { id });
    }
}