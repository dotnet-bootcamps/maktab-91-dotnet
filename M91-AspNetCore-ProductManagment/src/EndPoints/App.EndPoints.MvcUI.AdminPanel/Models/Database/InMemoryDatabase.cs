using App.EndPoints.MvcUI.AdminPanel.Models.Entities;
using System.Reflection;

namespace App.EndPoints.MvcUI.AdminPanel.Models.Database
{
    public class InMemoryDatabase
    {

        private static List<Product> _productList = new List<Product>();

        public List<Product> GetAllProducts()
        {
            return _productList;
        }


        public Product FindProduct(int id)
        {
            var selectedProduct = _productList.Find(x=>x.Id==id);

            if (selectedProduct is null)
                throw new Exception($"There is no product with id {id}");

            return selectedProduct;
        }

        public void AddProduct(Product model)
        {
            model.Id = _getLastProductId();
            _productList.Add(model);
        }

        public void UpdateProduct(Product model)
        {
            var selectedProduct = FindProduct(model.Id);

            selectedProduct.Title = model.Title;
            selectedProduct.Price = model.Price;
            selectedProduct.Qty = model.Qty;
        }

        public void DeleteProduct(int id)
        {
            var selectedProduct = FindProduct(id);
            _productList.Remove(selectedProduct);
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



        #region _privateMethods
        private int _getLastProductId()
        {
            var lastProductRecord = _productList.OrderByDescending(o => o.Id).FirstOrDefault();

            if (lastProductRecord is null)
                return 1;
            else
                return lastProductRecord.Id + 1;
        }
        #endregion
    }
}
