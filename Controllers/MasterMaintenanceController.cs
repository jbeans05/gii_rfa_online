using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_rfa.Models;

namespace Paperless_rfa.Controllers;

public class MasterMaintenanceController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public MasterMaintenanceController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult MasterItem()
    {
          ViewBag.titlePage = "Item";       
        return View();
    }

    [HttpPost]
    public  IActionResult Mastritem(IFormFile files){
      return View(files);
    }


    public IActionResult MasterSupplier()
    {
         ViewBag.titlePage = " Supplier";  
        return View();
    }

    public IActionResult MasterDepartemen()
    {
         ViewBag.titlePage = " Departement";  
        return View();
    }


    public IActionResult ManageUser()
    {
         ViewBag.titlePage = "User";  
        return View();
    }

    public IActionResult ManageRole()
    {
         ViewBag.titlePage = "Role";  
        return View();
    }

    public IActionResult ManageUserRole(){
        ViewBag.titlePage ="User Role";
        return View();
    }

    public IActionResult ManageEmployee(){
        ViewBag.titlePage ="Employee";
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
