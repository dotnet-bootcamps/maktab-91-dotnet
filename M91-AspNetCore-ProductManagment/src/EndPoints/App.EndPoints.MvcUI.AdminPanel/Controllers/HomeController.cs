using App.EndPoints.MvcUI.AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using App.Domain.Core.Entities;
using App.EndPoints.MvcUI.AdminPanel.Models.ViewModels;

namespace App.EndPoints.MvcUI.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var product = new Product
            {
                Id = -1,
                Price = 0,
                Qty = 0,
                Title = "نا مشخص"
            };

            ViewBag.SingleProduct = product;
            ViewBag.HeaderHtmlContent = "<script>alert('hi'); </script>salam sdasd asdasd asd <h1>This is html content</h1>";
            return View(product);
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