using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Controllers;

public class FriendsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}