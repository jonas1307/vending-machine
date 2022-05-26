using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Contracts;
using VendingMachine.Domain.Contracts;
using VendingMachine.Web.Models;

namespace VendingMachine.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMachineService _machineService;
        private readonly IProductGrid _productGrid;

        public HomeController(ILogger<HomeController> logger, IMachineService machineService, IProductGrid productGrid)
        {
            _logger = logger;
            _machineService = machineService;
            _productGrid = productGrid;
        }

        public IActionResult Index()
        {
            var availableCurrency = FormatCurrency(_machineService.GetPaidAmmount());
            var product = _productGrid.GetAllProducts();

            var model = new HomeViewModel(availableCurrency, product);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCoin(int faceValue)
        {
            _machineService.AddCoin(faceValue);

            TempData["SuccessMessage"] = $"{FormatCurrency(faceValue)} coin has been added";

            _logger.LogTrace($"User added {FormatCurrency(faceValue)} coin");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectProduct(int productId)
        {
            try
            {
                var sale = _machineService.SellProduct(productId);

                var product = sale.Product;
                var change = sale.Change;

                var message = $"Thank you for your purchase! Sold {product.Name} for {FormatCurrency(product.Value)}";

                if (change.Any())
                {
                    var groupedCoins = change
                        .GroupBy(x => x)
                        .Select(x => new { FaceValue = x.Key, Quantity = x.Count() })
                        .OrderBy(x => x.FaceValue);

                    var formattedCoins = groupedCoins
                        .Select(x => $"{FormatCurrency(x.FaceValue)} x {x.Quantity} coin(s)");

                    message += $" Your change: {string.Join(", ", formattedCoins)}";
                }

                TempData["SuccessMessage"] = message;

                _logger.LogTrace($"User bought product with id {productId}");
            }
            catch (Exception ex)
            {
                TempData["AlertMessage"] = ex.Message;

                _logger.LogError(ex, $"Error while selling product with id {productId}");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReturnCoins()
        {
            var coins = _machineService.ReleaseCoins();

            if (coins.Any())
            {
                var groupedCoins = coins
                .GroupBy(x => x)
                .Select(x => new { FaceValue = x.Key, Quantity = x.Count() })
                .OrderBy(x => x.FaceValue);

                var formattedCoins = groupedCoins
                    .Select(x => $"{FormatCurrency(x.FaceValue)} x {x.Quantity} coin(s)");

                TempData["SuccessMessage"] = $"Your coins have been returned: {string.Join(", ", formattedCoins)}";

                _logger.LogTrace($"Coins were returned to user");
            }
            else
            {
                TempData["AlertMessage"] = "No coins to return";
            }

            return RedirectToAction("Index");
        }

        private static string FormatCurrency(int ammount) => ((decimal)ammount / 100).ToString("C", CultureInfo.GetCultureInfo("en-US"));
    }
}
