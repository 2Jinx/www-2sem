using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Controllers;

public class WalletController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}