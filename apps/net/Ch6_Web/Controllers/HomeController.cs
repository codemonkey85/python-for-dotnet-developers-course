using System.Diagnostics;
using Ch6_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch6_Web.Controllers;

public class HomeController : Controller
{
    public HomeController(ILogger<HomeController> logger)
    {
    }

    public IActionResult Index() => View();

    public IActionResult Guitars(string id)
    {
        var vm = new GuitarsViewModel(id);
        return View(vm);
    }

    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
