using Microsoft.AspNetCore.Mvc;
using Tarefas.Models;
using Tarefas.Services;

namespace Tarefas.Controllers;

public class TaskController : Controller
{
    private readonly TaskService _taskService;

    public TaskController(TaskService userService)
    {
        _taskService = userService;
    }
    
    public async Task<IActionResult> Create()
    {
        return View();
    }

    public async Task<IActionResult> Index()
    {
        var tasks = await _taskService.GetTasks();
        return View(tasks);
    }
    
    public async Task<IActionResult> Detail(int id)
    {
        var task = await _taskService.GetTask(id);
        return View(task);
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var task = await _taskService.GetTask(id);
        return View(task);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        await _taskService.DeleteTask(id);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        await _taskService.AddTask(item);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Edit(Item item)
    {
        await _taskService.UpdateTask(item);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Delete(Item item)
    {
        await _taskService.DeleteTask(item.Id);
        return RedirectToAction("Index");
    }
    
}