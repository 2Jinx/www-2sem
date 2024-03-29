using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}