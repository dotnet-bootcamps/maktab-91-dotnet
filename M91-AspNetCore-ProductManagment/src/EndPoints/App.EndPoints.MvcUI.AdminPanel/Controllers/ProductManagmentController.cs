using App.EndPoints.MvcUI.AdminPanel.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUI.AdminPanel.Controllers
{
    public class ProductManagementController : Controller
    {
        private static List<Product> _productList = new List<Product>();
        

        public IActionResult Index()
        {
            return View("Index", _productList);
        }

        public IActionResult ShowDetails(int id)
        {
            var selectedProduct = _productList.Find(x => x.Id == id);

            if (selectedProduct is null)
                throw new Exception($"There is no product with id {id}");

            return View(selectedProduct);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var selectedProduct = _productList.Find(x => x.Id == id);

            if (selectedProduct is null)
                throw new Exception($"There is no product with id {id}");

            return View(selectedProduct);
        }
        
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var selectedProduct = _productList.Find(x => x.Id == model.Id);

            if (selectedProduct is null)
                throw new Exception($"There is no product with id {model.Id}");

            selectedProduct.Title = model.Title;
            selectedProduct.Price = model.Price;
            selectedProduct.Qty = model.Qty;

            return RedirectToAction("Index");
            // return View("Index", _productList);
        }

        public string SeedData()
        {
            if (_productList.Any() == false)
            {
                _productList.Add(new Product
                {
                    Id = 1,
                    Title = "Laptop",
                    Price = 1000,
                    Qty = 10
                });

                _productList.Add(new Product
                {
                    Id = 2,
                    Title = "Mobile",
                    Price = 500,
                    Qty = 15
                });

                return "Seed Data Successfully";
            }
            else
            {
                return "You can't seed again";
            }
        }
        
    }
}
