using App.Domain.Core.Entities;
using App.Infrasructures.DataAccess.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.UI.MvcAndPages.Pages.Products
{
    public class AddModel : PageModel
    {
        private InMemoryDatabase _inMemoryDatabase;

        public AddModel()
        {
            _inMemoryDatabase = new InMemoryDatabase();
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        {
            Product = new Product();
        }

        public IActionResult OnPost()
        {
            _inMemoryDatabase.AddProduct(Product);
            return RedirectToPage("List");
        }
    }
}
