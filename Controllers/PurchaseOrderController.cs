using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_rfa.Models;

namespace Paperless_rfa.Controllers;

public class PurchaseOrderController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public PurchaseOrderController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult CreatePUO()
    {
         ViewBag.titlePage = "Create Purchase order";  
        return View();
    }

    public IActionResult ViewPUO()
    {
         ViewBag.titlePage = "View Purchase Order";  
        return View();
    }

    public IActionResult test()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
