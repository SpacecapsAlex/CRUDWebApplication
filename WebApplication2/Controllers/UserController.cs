using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _userService.GetAll());
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid userId)
    {
        return View(await _userService.GetById(userId));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(User user)
    {
        await _userService.Remove(user.Id);
        return RedirectToAction("Index", "User");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new User());
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        if (user.Name == string.Empty || user.Country == string.Empty || user.Age <= 0)
        {
            ModelState.AddModelError("", "Данные не верны!");
            return View(user);
        }
        await _userService.Create(user);
        return RedirectToAction("Index", "User");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid userId)
    {
        return View(await _userService.GetById(userId));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(User user)
    {
        if (user.Name == string.Empty || user.Country == string.Empty || user.Age <= 0)
        {
            ModelState.AddModelError("", "Данные не верны!");
            return View(user);
        }
        await _userService.Edit(user);
        return RedirectToAction("Index", "User");
    }
}