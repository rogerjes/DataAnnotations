using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DataAnnotationsExample.Models;

namespace DataAnnotationsExample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    [HttpGet]
    public IActionResult Submit()
    {
        User user = new User();

        // If the model state is invalid, return the same view with validation messages
        return View("User", user);
    }

    [HttpPost]
    public IActionResult Submit(User user)
    {
        
        if (ModelState.IsValid)
        {
            // Handle the valid model (e.g., save to database)
            return RedirectToAction("Index");
        }
        // If the model state is invalid, return the same view with validation messages
        return View("User", user);
    }



}
