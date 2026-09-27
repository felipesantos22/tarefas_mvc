using Tarefas.Models;

namespace Tarefas.Repositories;

using Microsoft.AspNetCore.Identity;
using Tarefas.Interfaces;

public class IdentityRepository : IIdentityRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public IdentityRepository(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> LoginAsync(
        string email,
        string password,
        bool rememberMe)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            return false;

        var result = await _signInManager.PasswordSignInAsync(
            user.UserName!,
            password,
            rememberMe,
            lockoutOnFailure: false);

        return result.Succeeded;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<IdentityResult> RegisterAsync(
        string email,
        string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        return await _userManager.CreateAsync(user, password);
    }
}