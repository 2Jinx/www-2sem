using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Controllers;

public class StreamsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}