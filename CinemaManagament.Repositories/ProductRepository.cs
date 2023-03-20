
using CinemaManagamentAppication.Models;
using System.Collections.Generic;



namespace CinemaManagament.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository()
        {

            Data = new List<Product>() 
            {
                new Product(){Id = 1,Name = "Skopsko", Price = 120, Quantity=85},
                new Product(){Id = 2, Name = "Coca Cola", Price = 80, Quantity = 63}
            };
        }
       

        

    }
}

