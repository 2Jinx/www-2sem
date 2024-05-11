using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

public class FriendsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}