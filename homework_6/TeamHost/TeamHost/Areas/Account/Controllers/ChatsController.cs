using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

public class ChatsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}