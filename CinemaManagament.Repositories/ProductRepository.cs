using CinemaManagamentAppication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaManagament.Repositories
{
    public class ProductRepository
    {
        public ProductRepository()
        {

            Products = new List<Product>();
        }
        private List<Product> Products { get; set; }

        public void CreateProduct(Product newProduct)
        {
            newProduct.Id = GenerateProductId();
            Products.Add(newProduct);
        }

        public Product GetByName(string userInputProductName)
        {
            return Products.FirstOrDefault(x => x.Name == userInputProductName);
        }

        private int GenerateProductId()
        {

            {
                var newId = 0;

                if (Products.Count > 0)
                {
                    newId = Products.Max(x => x.Id);

                }
                return newId + 1;
            }
        }
    }
}

