using System.Diagnostics;
using Ch7_Db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ch7_Db.Controllers;

public class HomeController : Controller
{
    public HomeController(ILogger<HomeController> logger)
    {
    }

    public IActionResult Index() => View();

    public IActionResult Guitars(string id)
    {
        var style = id;
        var vm = new GuitarsViewModel(style);
        return View(vm);
    }

    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
