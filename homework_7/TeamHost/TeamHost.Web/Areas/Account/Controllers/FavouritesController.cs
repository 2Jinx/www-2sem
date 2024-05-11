using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

public class Favourites : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}