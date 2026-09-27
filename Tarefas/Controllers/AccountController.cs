using Microsoft.AspNetCore.Mvc;
using Tarefas.Interfaces;
using Tarefas.Models;

namespace Tarefas.Controllers;

public class AccountController : Controller
{
    private readonly IIdentityRepository _identityRepository;

    public AccountController(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _identityRepository.LoginAsync(
            model.Email,
            model.Password,
            model.RememberMe);

        if (!result)
        {
            ModelState.AddModelError(
                string.Empty,
                "E-mail ou senha inválidos.");

            return View(model);
        }

        return RedirectToAction("Index", "Task");
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _identityRepository.RegisterAsync(
            model.Email,
            model.Password
            );

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    error.Description);
            }

            return View(model);
        }

        await _identityRepository.LoginAsync(
            model.Email,
            model.Password,
            false);

        return RedirectToAction("Index", "Task");
    }

   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _identityRepository.LogoutAsync();

        return RedirectToAction(nameof(Login));
    }
    
    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}