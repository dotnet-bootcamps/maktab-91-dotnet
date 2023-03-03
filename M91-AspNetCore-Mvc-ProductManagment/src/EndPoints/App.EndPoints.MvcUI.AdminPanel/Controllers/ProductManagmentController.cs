using App.EndPoints.MvcUI.AdminPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUI.AdminPanel.Controllers
{
    public class ProductManagementController : Controller
    {
        public IActionResult Index()
        {
            var productListViewModel = new List<ProductViewModel>();

            productListViewModel.Add(new ProductViewModel
            {
                Id = 1,
                Title = "Laptop",
                Price = 1000,
                Qty = 10
            });

            productListViewModel.Add(new ProductViewModel
            {
                Id = 2,
                Title = "Mobile",
                Price = 500,
                Qty = 15
            });

            return View("Index", productListViewModel);
        }
        
    }
}
