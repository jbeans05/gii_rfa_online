using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_rfa.Models;

namespace Paperless_rfa.Controllers;

public class RequestFormApprovalController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public RequestFormApprovalController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult CreateRFA()
    {
         ViewBag.titlePage = "Create RFA";  
        return View();
    }
    public IActionResult CreateRFAforGA(){
        ViewBag.titlePage ="Create RFA for GA";
        return View();
    }

    public IActionResult ViewRFA()
    {
         ViewBag.titlePage = "View RFA";  
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
