using Tarefas.Interfaces;
using Tarefas.Models;

namespace Tarefas.Services;

public class TaskService
{
    private readonly ITaskRepository _userRepository;

    public TaskService(ITaskRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task AddTask(Item item) => await _userRepository.AddTask(item);
    public async Task<List<Item>> GetTasks() => await _userRepository.GetTasks();
    public async Task<Item> GetTask(int id) => await _userRepository.GetTask(id);
    public async Task UpdateTask(Item item) => await _userRepository.UpdateTask(item);
    public async Task DeleteTask(int id) => await _userRepository.DeleteTask(id);
    
}