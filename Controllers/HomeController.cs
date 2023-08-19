using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_rfa.Models;

namespace Paperless_rfa.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {   
        ViewBag.titlePage = "Dashboard";       
        return View();
    }

    public IActionResult Privacy()
    {
          ViewBag.titlePage = "About";       
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
