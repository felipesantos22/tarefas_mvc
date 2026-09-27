using Microsoft.AspNetCore.Identity;

namespace Tarefas.Services;

using Tarefas.Interfaces;

public class IdentityService : IIdentityRepository
{
    private readonly IIdentityRepository _identityRepository;

    public IdentityService(
        IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<bool> LoginAsync(
        string email,
        string password,
        bool rememberMe)
    {
        return await _identityRepository.LoginAsync(
            email,
            password,
            rememberMe);
    }

    public async Task LogoutAsync()
    {
        await _identityRepository.LogoutAsync();
    }

    public async Task<IdentityResult> RegisterAsync(
        string email,
        string password)
    {
        return await _identityRepository.RegisterAsync(
            email,
            password);
    }
}