using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Controllers;

public class ChatsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}