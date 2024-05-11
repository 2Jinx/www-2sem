using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Main.Controllers;

public class StreamsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}