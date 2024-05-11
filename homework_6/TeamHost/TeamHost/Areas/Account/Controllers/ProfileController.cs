using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}