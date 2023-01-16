using System.Diagnostics;
using frontend.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;

namespace frontend.Backoffice.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("~/Backoffice/Views/Home/Index.cshtml");
    }

    public IActionResult Privacy()
    {
        return View("~/Backoffice/Views/Home/Privacy.cshtml");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("~/Backoffice/Views/Shared/Error.cshtml",new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}