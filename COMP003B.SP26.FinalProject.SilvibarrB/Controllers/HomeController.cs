using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using COMP003B.SP26.FinalProject.SilvibarrB.Models;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Controllers;

public class HomeController : Controller
{
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
    public IActionResult Test(string? id)
    {
        return Content($"Message: {id}");
    }
}