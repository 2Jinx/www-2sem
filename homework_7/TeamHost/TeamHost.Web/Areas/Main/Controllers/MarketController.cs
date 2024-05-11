using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Main.Controllers;

public class MarketController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}