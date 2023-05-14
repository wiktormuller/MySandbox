using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRBasics.Hubs;
using SignalRBasics.Models;
using System.Diagnostics;

namespace SignalRBasics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DeathlyHallowsHub> _deathlyHallowsHub;

        public HomeController(ILogger<HomeController> logger, 
            IHubContext<DeathlyHallowsHub> deathlyHallowsHub)
        {
            _logger = logger;
            _deathlyHallowsHub = deathlyHallowsHub;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> DeathlyHallows(string type)
        {
            if (StaticDetails.DealthyHallowRace.ContainsKey(type))
            {
                StaticDetails.DealthyHallowRace[type]++;
            }

            await _deathlyHallowsHub.Clients.All.SendAsync(
                "updateDeathlyHallowsCount",
                StaticDetails.DealthyHallowRace[StaticDetails.Cloak], 
                StaticDetails.DealthyHallowRace[StaticDetails.Stone], 
                StaticDetails.DealthyHallowRace[StaticDetails.Wand]);

            return Accepted();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}