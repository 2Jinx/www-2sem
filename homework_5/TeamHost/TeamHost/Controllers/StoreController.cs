using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Controllers;

public class StoreController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}