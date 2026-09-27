using Microsoft.AspNetCore.Identity;

namespace Tarefas.Interfaces;

public interface IIdentityRepository
{
    Task<IdentityResult> RegisterAsync(
        string email,
        string password);
    
    
    Task<bool> LoginAsync(
        string email,
        string password,
        bool rememberMe);

    Task LogoutAsync();
}