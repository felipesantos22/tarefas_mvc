using Tarefas.Models;

namespace Tarefas.Interfaces;

public interface ITaskRepository
{
    Task AddTask(Item item);
    Task<List<Item>> GetTasks();
    Task<Item> GetTask(int id);
    Task UpdateTask(Item item);
    Task DeleteTask(int id);
}