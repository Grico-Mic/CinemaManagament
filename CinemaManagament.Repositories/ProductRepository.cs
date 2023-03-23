
using CinemaManagamentAppication.Models;




namespace CinemaManagament.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository() :base("Product.txt")
        {

        }
       

        

    }
}

