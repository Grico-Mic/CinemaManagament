using CinemaManagament.Repositories.Common;
using CinemaManagamentAppication.Models;
using System.Collections.Generic;
using System.Linq;


namespace CinemaManagament.Repositories
{
    public class ProductRepository
    {
        public ProductRepository()
        {

            _products = new List<Product>() 
            {
                new Product(){Id = 1,Name = "Skopsko", Price = 120, Quantity=85},
                new Product(){Id = 2, Name = "Coca Cola", Price = 80, Quantity = 63}
            };
        }
        private List<Product> _products { get; set; }

        public void CreateProduct(Product newProduct)
        {
            newProduct.Id = IdGenerator.GenerateId<Product >(_products);
            _products.Add(newProduct);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetByName(string userInputProductName)
        {
            return _products.FirstOrDefault(x => x.Name == userInputProductName);
        }

        public void Remove(Product choosenProduct)
        {
            _products.Remove(choosenProduct);
        }
        

        
    }
}

