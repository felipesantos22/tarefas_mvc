using Microsoft.AspNetCore.Mvc;

namespace Tarefas.Controllers;

public class UserController : Controller
{
    public IActionResult Index() => View();
}