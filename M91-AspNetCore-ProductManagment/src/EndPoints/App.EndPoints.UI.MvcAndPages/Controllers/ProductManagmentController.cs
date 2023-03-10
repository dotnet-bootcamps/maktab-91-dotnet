using App.Domain.Core.Entities;
using App.Infrasructures.DataAccess.Database;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.UI.MvcAndPages.Controllers
{
    public class ProductManagementController : Controller
    {
        private InMemoryDatabase _inMemoryDatabase;

        public ProductManagementController()
        {
            _inMemoryDatabase = new InMemoryDatabase();
        }

        public IActionResult Index()
        {
            //
            //
            //
            //
            return View("Index", _inMemoryDatabase.GetAllProducts());
        }

        public IActionResult Add()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Add(Product newProductModel)
        {
            _inMemoryDatabase.AddProduct(newProductModel);
            return RedirectToAction("Index");
        }

        public IActionResult ShowDetails(int id)
        {
            var selectedProduct = _inMemoryDatabase.FindProduct(id);
            return View(selectedProduct);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var selectedProduct = _inMemoryDatabase.FindProduct(id);
            return View(selectedProduct);
        }
        
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var selectedProduct = _inMemoryDatabase.FindProduct(model.Id);
            _inMemoryDatabase.UpdateProduct(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var selectedProduct = _inMemoryDatabase.FindProduct(id);
            return View(selectedProduct);
        }

        [HttpPost]
        public IActionResult Delete(Product model)
        {
            _inMemoryDatabase.DeleteProduct(model.Id);
            return RedirectToAction("Index");
        }
        
    }
}
