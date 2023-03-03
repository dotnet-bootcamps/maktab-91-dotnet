using App.Domain.Core.Entities;
using App.Infrasructures.DataAccess.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.PagesUI.AdminPanel.Pages.Products
{
    public class ListModel : PageModel
    {
        private InMemoryDatabase _inMemoryDatabase;

        public ListModel()
        {
            _inMemoryDatabase = new InMemoryDatabase();
        }

        [BindProperty]
        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _inMemoryDatabase.GetAllProducts();
        }
        public void OnPost()
        {

        }
    }
}
