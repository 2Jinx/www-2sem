using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

public class WalletController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}