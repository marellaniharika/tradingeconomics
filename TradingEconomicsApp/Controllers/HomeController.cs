using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradingEconomicsApp.Services;
using TradingEconomicsApp.Models;

namespace TradingEconomicsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TradingEconomicsService _tradingEconomicsService;
        private const string Username = "7f245f298a2b479"; 
        private const string Password = "lg0itm87h6lwaig"; 

        public HomeController(TradingEconomicsService tradingEconomicsService)
        {
            _tradingEconomicsService = tradingEconomicsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Compare(string country1, string country2)
        {
            var data1 = await _tradingEconomicsService.GetGdpDataAsync(country1, Username, Password);
            var data2 = await _tradingEconomicsService.GetGdpDataAsync(country2, Username, Password);

            ViewBag.Country1 = country1;
            ViewBag.Country2 = country2;
            ViewBag.Data1 = data1;
            ViewBag.Data2 = data2;

            return View("Index");
        }
    }
}