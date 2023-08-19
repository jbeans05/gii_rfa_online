using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_rfa.Models;

namespace Paperless_rfa.Controllers;

public class RequestOrderController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public RequestOrderController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult CreateRequestOrder()
    {
         ViewBag.titlePage = "Create Request Order";  
        return View();
    }

    public IActionResult ViewRequestOrder()
    {
         ViewBag.titlePage = "View Request Order";  
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
