using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_rfa.Models;

namespace Paperless_rfa.Controllers;

public class PaymentOrderController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public PaymentOrderController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult CreatePO()
    {
         ViewBag.titlePage = "Create Payment Order";  
        return View();
    }

    public IActionResult ViewPO()
    {
         ViewBag.titlePage = "View Paymnet Orders";  
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
