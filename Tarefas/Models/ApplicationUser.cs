using Microsoft.AspNetCore.Identity;

namespace Tarefas.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } = string.Empty;
}