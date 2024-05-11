using Microsoft.AspNetCore.Mvc;
using TeamHost.Interfaces;

namespace TeamHost.Areas.Main.Controllers;

public class StoreController(IStoreService storeService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var games = await storeService.GetAllGames(); 

        return View(games); 
    }
    
    [HttpGet("Store/item/{id}")]
    public IActionResult Details([FromRoute] int id)
    {
        var game = storeService.GetGameById((uint)id); 

        return View(game); 
    }
}