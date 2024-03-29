using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Controllers;

public class CommunityController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}