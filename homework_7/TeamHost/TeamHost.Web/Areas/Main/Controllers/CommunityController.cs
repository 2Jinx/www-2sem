using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Main.Controllers;

public class CommunityController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}