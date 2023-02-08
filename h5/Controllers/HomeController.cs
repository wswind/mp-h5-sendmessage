using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestPage.Models;

namespace TestPage.Controllers;

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
    public IActionResult Test()
    {
        return Redirect("http://localhost:5139/redirect");
    }

    [HttpGet]
    [Route("/redirect")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult RedirectAction(string code, string state)
    {
        string msg = $"wecom redirect - code:{code} state:{state}";
        ViewBag.Code = code;
        _logger.LogInformation(msg);
        return View("Redirect");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
