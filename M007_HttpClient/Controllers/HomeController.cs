using M007_HttpClient.Models;
using M007_HttpClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace M007_HttpClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleClientService _clientService;

        public HomeController(ILogger<HomeController> logger, IVehicleClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _clientService.FetchVehicles();
            return View(result);
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
