using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Controllers;

public class MarketController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}